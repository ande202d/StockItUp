using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp
{
    public class FirstTestClass
    {

        private List<Product> _test;
        public FirstTestClass()
        {
            Product p1 = new Product("1", 1);
            Product p2 = new Product("2", 2, new Supplier("s1", "www.hejmeddig.dk"));
            Product p3 = new Product("3", 3);
            Product p4 = new Product("4", 4, new Supplier("s2", "www.hejmeddigv2.dk"));
            Product p5 = new Product("5", 5);
            _test = new List<Product>(){p1,p2,p3,p4,p5};
        
        }

        public List<Product> Test
        {
            get { return _test;} }
        

        

        
        //det er bare for at tjekke vi alle har det samme
        //Hvis du kan se dette er den skabt
    }
}
