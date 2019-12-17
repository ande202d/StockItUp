using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RVG.Common;
using StockItUp.Annotations;
using StockItUp.Connections;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class StorePageViewModel : BaseViewModel
    {

        private Store _selectedStore;
        private List<StorePageUser> _storePageUsers;

        public StorePageViewModel()
        {
            SaveChangesCommand = new RelayCommand(SaveChangesMethod);
            CreateStoreCommand = new RelayCommand(CreateStoreMethod);
            DeleteStoreCommand = new RelayCommand(DeleteStoreMethod);
            EditStoreCommand = new RelayCommand(EditStoreMethod);
        }

        public ICommand SaveChangesCommand { get; set; }
        public ICommand CreateStoreCommand { get; set; }
        public ICommand DeleteStoreCommand { get; set; }
        public ICommand EditStoreCommand { get; set; }

        public PermissionGroup Permission
        {
            get { return Catalog<PermissionGroup>.Instance.Read(Controller.Instance.GetUser.GroupId).Result; }
        }

        public ObservableCollection<Store> StoreCatalog
        {
            get { return new ObservableCollection<Store>(Catalog<Store>.Instance.GetList);}
        }

        public Store SelectedStore
        {
            get
            {
                if (_selectedStore == null)
                {
                    _selectedStore = new Store();
                }
                return _selectedStore;

            }

            set
            {
                _selectedStore = value;
                OnPropertyChanged(nameof(StorePageUserCatalog));
                OnPropertyChanged();
            }
        }

        public ObservableCollection<StorePageUser> StorePageUserCatalog
        {
            get
            {
                List<StorePageUser> listToReturn = new List<StorePageUser>();

                foreach (User u in Catalog<User>.Instance.GetList)
                {
                    string s = u.Name;
                    bool b = false;

                    foreach (UserStore us in Catalog<UserStore>.Instance.GetList)
                    {
                        if (us.UserId == u.Id && us.StoreId == SelectedStore.Id)
                        {
                            b = true;
                        }
                    }
                    listToReturn.Add(new StorePageUser(s, b, u.Id));
                }

                _storePageUsers = listToReturn;
                return new ObservableCollection<StorePageUser>(listToReturn);
            }
            //set { _storePageUsers = value.ToList(); }
        }

        public Controller Controller
        {
            get { return Controller.Instance; }
        }

        public async void SaveChangesMethod()
        {
            foreach (UserStore us in Catalog<UserStore>.Instance.GetList)
            {
                if (us.StoreId == SelectedStore.Id)
                {
                    await Catalog<UserStore>.Instance.Delete(us.Id);
                }
            }
            foreach (StorePageUser spu in _storePageUsers)
            {
                if (spu.WorksAtStore)
                {
                    await Catalog<UserStore>.Instance.Create(new UserStore(spu.UserId, SelectedStore.Id));
                }
            }
            OnPropertyChanged();
            OnPropertyChanged(nameof(StorePageUserCatalog));
        }

        public async void CreateStoreMethod()
        {
            await Catalog<Store>.Instance.Create(SelectedStore);
            OnPropertyChanged(nameof(StoreCatalog));
        }

        public async void EditStoreMethod()
        {
            await Catalog<Store>.Instance.Update(SelectedStore.Id, SelectedStore);
            OnPropertyChanged(nameof(StoreCatalog));
        }

        public async void DeleteStoreMethod()
        {
           await Catalog<Store>.Instance.Delete(SelectedStore.Id);
           OnPropertyChanged(nameof(StoreCatalog));
        }
    }
}
