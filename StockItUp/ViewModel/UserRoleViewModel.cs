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
    public class UserRoleViewModel : INotifyPropertyChanged
    {

        #region Instance fields

        private Visibility _createVisibility = Visibility.Visible;
        private Visibility _dataVisibility = Visibility.Collapsed;
        private PermissionGroup _selectedGroup;
        #endregion


        #region Constructor
        public UserRoleViewModel()
        {
            CreateGroupCommand = new RelayCommand(CreateGroupMethod);
        }
        #endregion

        #region Properties

        public ICommand CreateGroupCommand { get; set; }

        public ObservableCollection<PermissionGroup> GroupCatalog
        {
            get
            {
                return new ObservableCollection<PermissionGroup>(Catalog<PermissionGroup>.Instance.GetList);
            }
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
                OnPropertyChanged(nameof(GetPermissionCatalog));
            }
        }

        public ObservableCollection<KeyValuePair<string, bool>> GetPermissionCatalog
        {
            get
            {
                return new ObservableCollection<KeyValuePair<string, bool>>(SelectedGroup.GetPermissions);
            }
        }

        #endregion


        public async void CreateGroupMethod()
        {
            SelectedGroup.CanCreateProduct = GetPermissionCatalog[0].Value;
            SelectedGroup.CanDeleteProduct = GetPermissionCatalog[1].Value;
            SelectedGroup.CanUpdateProduct = GetPermissionCatalog[2].Value;
            
            await Catalog<PermissionGroup>.Instance.Create(SelectedGroup);
            OnPropertyChanged(nameof(GroupCatalog));

        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
