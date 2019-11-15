using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp
{
    public class FirstTestClass
    {

        private ObservableCollection<Product> _test;
        public FirstTestClass()
        {
            Product p1 = new Product("Classic", 24, new Supplier("s1", "www.tuborg.dk"));
            Product p2 = new Product("Stolichnaya", 6, new Supplier("s2", "www.Stolichnaya.com"));
            Product p3 = new Product("Breezer", 24, new Supplier("s3", "www.breezer.dk"));
            Product p4 = new Product("Mokai", 24, new Supplier("s4", "www.mokaaai.dk"));
            Product p5 = new Product("Brugal Anejo", 6, new Supplier("s5", "www.BrugalAnejo.dk"));
            _test = new ObservableCollection<Product>(){p1,p2,p3,p4,p5};
        
        }

        public ObservableCollection<Product> Test
        {
            get { return _test;} }
        

        

        
        //det er bare for at tjekke vi alle har det samme
        //Hvis du kan se dette er den skabt
    }
}
