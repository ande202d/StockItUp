using System;
using System.Collections;
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
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class UserRoleViewModel : BaseViewModel
    {

        #region Instance fields

        private Visibility _createVisibility = Visibility.Visible;
        private Visibility _dataVisibility = Visibility.Collapsed;
        private PermissionGroup _selectedGroup;
        private List<GroupPagePermissionSet> _listOfPermissions;
        #endregion

        #region Constructor
        public UserRoleViewModel()
        {
            CreateGroupCommand = new RelayCommand(CreateGroupMethod);
            ShowCreateGroupCommand = new RelayCommand(ShowCreateGroupMethod);
            DeleteGroupCommand = new RelayCommand(DeleteGroupMethod);
        }
        #endregion

        #region Properties

        public ICommand CreateGroupCommand { get; set; }
        public ICommand ShowCreateGroupCommand { get; set; }
        public ICommand DeleteGroupCommand { get; set; }

        public ObservableCollection<PermissionGroup> GroupCatalog
        {
            get
            {
                return new ObservableCollection<PermissionGroup>(Catalog<PermissionGroup>.Instance.GetList);
            }
        }

        public PermissionGroup Permission
        {
            get { return Catalog<PermissionGroup>.Instance.Read(Controller.Instance.GetUser.GroupId).Result; }
        }

        public Visibility CreateVisibility
        {
            get { return _createVisibility; }
            set { _createVisibility = value; }
        }

        public Visibility DataVisibility
        {
            get { return _dataVisibility; }
            set { _dataVisibility = value; }
        }

        public PermissionGroup SelectedGroup
        {
            get
            {
                if (_selectedGroup == null) _selectedGroup = new PermissionGroup();

                return _selectedGroup;
            }
            set
            {
                _selectedGroup = value;
                CreateVisibility = Visibility.Collapsed;
                DataVisibility = Visibility.Visible; 
                OnPropertyChanged(nameof(CreateVisibility));
                OnPropertyChanged(nameof(DataVisibility));
                //OnPropertyChanged(nameof(GetPermissionCatalog));
                OnPropertyChanged(nameof(GetPermissionCatalog2));
            }
        }

        //public ObservableCollection<KeyValuePair<string, bool>> GetPermissionCatalog
        //{
        //    get
        //    {
        //        return new ObservableCollection<KeyValuePair<string, bool>>(SelectedGroup.GetPermissions);
        //    }
        //}

        public ObservableCollection<GroupPagePermissionSet> GetPermissionCatalog2
        {
            get
            {
                List<GroupPagePermissionSet> listToReturn = new List<GroupPagePermissionSet>();

                foreach (var v in SelectedGroup.GetPermissions)
                {
                    listToReturn.Add(new GroupPagePermissionSet(v.Key, v.Value));
                }

                _listOfPermissions = listToReturn;
                return new ObservableCollection<GroupPagePermissionSet>(listToReturn);
            }
        }

        public Controller Controller
        {
            get { return Controller.Instance; }
        }

        #endregion

        #region Methods
        public async void CreateGroupMethod()
        {
            SelectedGroup.CanCreateProduct = _listOfPermissions[0].State;
            SelectedGroup.CanDeleteProduct = _listOfPermissions[1].State;
            SelectedGroup.CanUpdateProduct = _listOfPermissions[2].State;

            SelectedGroup.CanCreateSupplier = _listOfPermissions[3].State;
            SelectedGroup.CanDeleteSupplier = _listOfPermissions[4].State;
            SelectedGroup.CanUpdateSupplier = _listOfPermissions[5].State;

            SelectedGroup.CanCreateLocation = _listOfPermissions[6].State;
            SelectedGroup.CanDeleteLocation = _listOfPermissions[7].State;
            SelectedGroup.CanUpdateLocation = _listOfPermissions[8].State;

            SelectedGroup.CanCreateInventoryCount = _listOfPermissions[9].State;
            SelectedGroup.CanDeleteInventoryCount = _listOfPermissions[10].State;
            SelectedGroup.CanViewInventoryCount = _listOfPermissions[11].State;

            SelectedGroup.CanCreateOrder = _listOfPermissions[12].State;
            SelectedGroup.CanDeleteOrder = _listOfPermissions[13].State;
            SelectedGroup.CanViewOrder = _listOfPermissions[14].State;

            SelectedGroup.CanChangeStoreProduct = _listOfPermissions[15].State;

            SelectedGroup.CanCreateUser = _listOfPermissions[16].State;
            SelectedGroup.CanDeleteUser = _listOfPermissions[17].State;
            SelectedGroup.CanUpdateUser = _listOfPermissions[18].State;

            SelectedGroup.CanCreatePermissionGroup = _listOfPermissions[19].State;
            SelectedGroup.CanDeletePermissionGroup = _listOfPermissions[20].State;
            SelectedGroup.CanUpdatePermissionGroup = _listOfPermissions[21].State;

            SelectedGroup.CanCreateStore = _listOfPermissions[22].State;
            SelectedGroup.CanDeleteStore = _listOfPermissions[23].State;
            SelectedGroup.CanUpdateStore = _listOfPermissions[24].State;

            await Catalog<PermissionGroup>.Instance.Create(SelectedGroup);
            OnPropertyChanged(nameof(GroupCatalog));

        }

        public void ShowCreateGroupMethod()
        {
            OnPropertyChanged(nameof(GroupCatalog));
            OnPropertyChanged(nameof(SelectedGroup));

            DataVisibility = Visibility.Collapsed;
            CreateVisibility = Visibility.Visible;

            OnPropertyChanged(nameof(DataVisibility));
            OnPropertyChanged(nameof(CreateVisibility));
        }

        public async void DeleteGroupMethod()
        {
            await Catalog<PermissionGroup>.Instance.Delete(SelectedGroup.Id);
            OnPropertyChanged(nameof(GroupCatalog));
            await Catalog<User>.Instance.ReadAll();
        } 
        #endregion


    }
}
