using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using RVG.Common;
using StockItUp.Annotations;
using StockItUp.Connections;
using StockItUp.Filter;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class OrderPageViewModel : INotifyPropertyChanged
    {

        #region Instance field

        private List<OrderPage> _listOfOrders;
        private OrderHistory _selectedOrderHistory;
        private Visibility _createVisibility = Visibility.Visible;
        private Visibility _dataVisibility = Visibility.Collapsed;
        private string _selectedSort;
        private Supplier _selectedSupplier;

        #endregion

        #region Constructor

        public OrderPageViewModel()
        {
            CreateOrderCommand = new RelayCommand(CreateOrderMethod);
            DeleteOrderCommand = new RelayCommand(DeleteOrderMethod);
            ResetSelectedSupplierCommand = new RelayCommand(ResetSelectedSupplierMethod);
        }


        #endregion

        

        #region Properties
        
        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand ResetSelectedSupplierCommand { get; set; }

        public PermissionGroup Permission
        {
            get { return Catalog<PermissionGroup>.Instance.Read(Controller.Instance.GetUser.GroupId).Result; }
        }

        public ObservableCollection<OrderPage> CreateOrderCatalog
        {
            get
            {
                List<OrderPage> listToReturn = new List<OrderPage>();

                foreach (var s in Catalog<Store>.Instance.GetList)
                {
                    if (s.Id == Controller.Instance.StoreId)
                    {
                        foreach (var sp in Catalog<StoreProduct>.Instance.GetList)
                        {
                            List<int> newestIcId = StoragePageViewModel.getNewstIcIds(sp.Product);

                            Product p = Catalog<Product>.Instance.Read(sp.Product).Result;
                            int t = 0;
                            int m;
                            int sa;
                            Supplier sup = p.MySupplier;

                            if (sp.Store == s.Id)
                            {
                                foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                                {
                                    if (newestIcId.Contains(icp.InventoryCount) && icp.Product == sp.Product)
                                    {
                                        t += icp.Amount;
                                    }
                                }

                                m = sp.Amount - t;
                                if (m < 0) m = 0;
                                sa = (int) Math.Ceiling((double) m / p.AmountPerBox);


                                listToReturn.Add(new OrderPage(p, t, m, sa, sup));
                            }
                        }
                    }  
                }

                if (SelectedSort == "Leverandør")
                {
                    listToReturn.Sort(new OrderPageFilterBySupplier());
                }

                if (SelectedSort == "Varer")
                {
                    listToReturn.Sort(new OrderPageFilterByVarer());
                }
                if (SelectedSupplier != null)
                {
                    List<OrderPage> templist = new List<OrderPage>();
                    foreach (var data in listToReturn)
                    {
                        if (data.SupplierName == SelectedSupplier.Name)
                        {
                            templist.Add(data);
                        }
                    }
                    listToReturn = templist;
                }
                _listOfOrders = listToReturn;
                ObservableCollection<OrderPage> collection = new ObservableCollection<OrderPage>(listToReturn);
                return collection;
            }
        }

        public ObservableCollection<OrderHistory> OrderHistoryCatalog
        {
            get
            {
                ObservableCollection<OrderHistory> collection = 
                    new ObservableCollection<OrderHistory>(Catalog<OrderHistory>.Instance.GetList);
                return collection;
            }
        }

        public OrderHistory SelectedOrderHistory
        {
            get
            {
                if (_selectedOrderHistory == null) return new OrderHistory();
                return _selectedOrderHistory;
            }
            set
            {
                _selectedOrderHistory = value; OnPropertyChanged();
                CreateVisibility = Visibility.Collapsed;
                DataVisibility = Visibility.Visible;
                OnPropertyChanged(nameof(CreateVisibility));
                OnPropertyChanged(nameof(DataVisibility));
                OnPropertyChanged(nameof(OrderHistoryDataCatalog));
            }
        }

        public ObservableCollection<OrderHistoryData> OrderHistoryDataCatalog
        {
            get
            {
                List<OrderHistoryData> listToReturn = new List<OrderHistoryData>();

                foreach (var i in Catalog<OrderHistoryData>.Instance.GetList)
                {
                    if (i.OrderHistory == SelectedOrderHistory.Id)
                    {
                        listToReturn.Add(i);
                    }
                }

                if (SelectedSort == "Leverandør")
                {
                    listToReturn.Sort(new OrderHistoryDataFilterBySupplier());
                }

                if (SelectedSort == "Varer")
                {
                    listToReturn.Sort(new OrderHistoryDataFilterByVarer());
                }

                if (SelectedSupplier != null)
                {
                    List<OrderHistoryData> templist = new List<OrderHistoryData>();
                    foreach (var data in listToReturn)
                    {
                        if (data.Supplier==SelectedSupplier.Name)
                        {
                            templist.Add(data);
                        }
                    }
                    listToReturn = templist;
                }
                ObservableCollection<OrderHistoryData> collection = new ObservableCollection<OrderHistoryData>(listToReturn);
                return collection;
            }
        }

        public Visibility CreateVisibility
        {
            get { return _createVisibility;}
            set { _createVisibility = value; }
        }

        public Visibility DataVisibility
        {
            get { return _dataVisibility; }
            set { _dataVisibility = value; }
        }

        public ObservableCollection<string> SortingCollection
        {
            get
            {
                List<string> sortList = new List<string>(){"Leverandør", "Varer"};
                return new ObservableCollection<string>(sortList);
            }
        }

        public string SelectedSort
        {
            get { return _selectedSort; }
            set { _selectedSort = value; OnPropertyChanged();OnPropertyChanged(nameof(CreateOrderCatalog));OnPropertyChanged(nameof(OrderHistoryDataCatalog)); }
        }

        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value; OnPropertyChanged(); OnPropertyChanged(nameof(CreateOrderCatalog)); OnPropertyChanged(nameof(OrderHistoryDataCatalog)); }
        }

        //returns an ObservableCollection of supplies collection based on what the catalog pulls from the database
        public ObservableCollection<Supplier> SupplierCatalog
        {
            get
            {
                List<Supplier> sl = new List<Supplier>();
                foreach (var orderPage in CreateOrderCatalog)
                {
                    if (orderPage.Supplier != null)
                    {
                        sl.Add(orderPage.Supplier);
                    }
                }
                
                return new ObservableCollection<Supplier>(sl);
            }
        }
        #endregion

        #region Methods

        public async void CreateOrderMethod()
        {
            if (CreateVisibility == Visibility.Visible)
            {
                Order order = new Order("hahahaha");
                await Catalog<Order>.Instance.Create(order);

                Order latestOrder =
                    Catalog<Order>.Instance.GetList.Find(x => x.OrderDate >= DateTime.Now.Subtract(TimeSpan.FromSeconds(5)));

                OrderHistory orderHistory = new OrderHistory(latestOrder);
                await Catalog<OrderHistory>.Instance.Create(orderHistory);

                bool gotData = false;

                foreach (var i in _listOfOrders)
                {
                    if (i.ActualAmount > 0)
                    {
                        OrderProduct op = new OrderProduct(latestOrder.Id, i.Product.Id, i.ActualAmount);
                        await Catalog<OrderProduct>.Instance.Create(op);

                        OrderHistoryData ohd = new OrderHistoryData(orderHistory.Id, i.Product.Name, i.SupplierName,
                            i.Missing, i.Product.AmountPerBox, i.SuggestedAmount, i.ActualAmount);
                        await Catalog<OrderHistoryData>.Instance.Create(ohd);

                        gotData = true;
                    }
                }

                if (gotData == false)
                {
                    await Catalog<Order>.Instance.Delete(order.Id);

                    await Catalog<OrderHistory>.Instance.Delete(orderHistory.Id);
                }
                OnPropertyChanged(nameof(OrderHistoryCatalog));
            }
            else
            {
                OnPropertyChanged(nameof(OrderHistoryCatalog));

                DataVisibility = Visibility.Collapsed;
                CreateVisibility = Visibility.Visible;

                OnPropertyChanged(nameof(DataVisibility));
                OnPropertyChanged(nameof(CreateVisibility));
            }
        }

        private void ResetSelectedSupplierMethod()
        {
            SelectedSupplier = null;OnPropertyChanged(nameof(SelectedSupplier));
        }

        public async void DeleteOrderMethod()
        {
            if (SelectedOrderHistory != null)
            {
                await Catalog<OrderHistory>.Instance.Delete(SelectedOrderHistory.Id);
                OnPropertyChanged(nameof(OrderHistoryCatalog));
            }
        }
        #endregion


        #region IPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
