using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using StockItUp.Annotations;
using StockItUp.Connections;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp
{
    public class FirstTestClass : INotifyPropertyChanged
    {
        private bool _showLocation;
        private Product _selectedProduct;
        private InventoryCount _selectedInvCount;
        private ObservableCollection<Product> _test;
        private ObservableCollection<InventoryCount> _invCount;
        private ObservableCollection<InventoryCountProduct> _invCountProduct;
        public FirstTestClass()
        {
            Product p1 = new Product("Classic", 24, new Supplier("s1", "www.tuborg.dk"));
            Product p2 = new Product("Stolichnaya", 6, new Supplier("s2", "www.Stolichnaya.com"));
            Product p3 = new Product("Breezer", 24, new Supplier("s3", "www.breezer.dk"));
            Product p4 = new Product("Mokai", 24, new Supplier("s4", "www.mokaaai.dk"));
            Product p5 = new Product("Brugal Anejo", 6, new Supplier("s5", "www.BrugalAnejo.dk"));

            InventoryCount i1 = new InventoryCount(new Location(new Store("Club Retro", "Lortevej 21"), "Bar 1" ));
            InventoryCount i2 = new InventoryCount(new Location(new Store("Club Retro", "Lortevej 22"), "Bar 2" ));

            InventoryCountProduct ip1 = new InventoryCountProduct(i1.Location.Id, p2.Id, 20);
            InventoryCountProduct ip2 = new InventoryCountProduct(i1.Location.Id, p4.Id, 150);
            InventoryCountProduct ip3 = new InventoryCountProduct(i2.Location.Id, p1.Id, 2124);

            _invCount = new ObservableCollection<InventoryCount>(){i1, i2};
            _invCountProduct = new ObservableCollection<InventoryCountProduct>(){ip1, ip2, ip3};



            _test = new ObservableCollection<Product>(){p1,p2,p3,p4,p5};
            _selectedProduct = _test[0];
            _selectedInvCount = _invCount[0];
            _showLocation = false;

            //Catalog<Product> CP = Catalog<Product>.Instance;
            //List<Product> LP = CP.ReadAll().Result;
            //int hej = LP.Count;

        }

        public ObservableCollection<Product> Test
        {
            get { return _test;}
        }

        public ObservableCollection<InventoryCount> InvCount
        {
            get { return _invCount; }
        }

        public ObservableCollection<InventoryCountProduct> InvCountProduct
        {
            get { return _invCountProduct; }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }

        public InventoryCount SelectedInvCount
        {
            get { return _selectedInvCount; }
            set { _selectedInvCount = value; OnPropertyChanged(); }
        }

        public bool ShowLocation
        {
            get { return _showLocation; }
            set { _showLocation = value; OnPropertyChanged(); OnPropertyChanged(nameof(LocationVisibility)); } 
        }


        public Visibility LocationVisibility
        {
            get { return ShowLocation ? Visibility.Visible : Visibility.Collapsed; }
        }
        

        
        //det er bare for at tjekke vi alle har det samme
        //Hvis du kan se dette er den skabt
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
