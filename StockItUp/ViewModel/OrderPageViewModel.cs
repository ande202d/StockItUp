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
        
        #endregion

        #region Constructor

        public OrderPageViewModel()
        {
            CreateOrderCommand = new RelayCommand(CreateOrderMethod);
        }


        #endregion

        #region Properties

        public ICommand CreateOrderCommand { get; set; }

        public ObservableCollection<OrderPage> CreateOrderCatalog
        {
            get
            {
                List<OrderPage> listToReturn = new List<OrderPage>();

                foreach (var s in Catalog<Store>.Instance.GetList)
                {
                    if (s.Id == 1)
                    {
                        foreach (var sp in Catalog<StoreProduct>.Instance.GetList)
                        {
                            List<int> newestIcId = StoragePageViewModel.getNewstIcIds(sp.Product);

                            #region Test Area

                            Product p = Catalog<Product>.Instance.Read(sp.Product).Result;
                            int t = 0;
                            int m;
                            int sa;
                            int a;
                            Supplier sup = p.MySupplier;

                            #endregion


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
                                sa = (int) Math.Ceiling((double) m / p.AmountPerBox);


                                listToReturn.Add(new OrderPage(p, t, m, sa, sup));
                            }
                        }
                    }  
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

        #endregion

        #region Methods

        public async void CreateOrderMethod()
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
