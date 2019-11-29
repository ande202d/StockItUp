using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        
        #endregion

        #region Constructor

        public OrderPageViewModel()
        {
            
        }


        #endregion

        #region Properties

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

        #endregion

        #region Methods

        public async void CreateOrderMethod()
        {
            // _listOfOrders giver listen af orders og de felter fra CreateOrderCatalog som vi skal bruge for at putte den information
            // ind i vores database
            // Selected Order skal laves

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
