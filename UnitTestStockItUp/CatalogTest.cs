using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockItUp.Model;
using StockItUp.Persistency;
using StockItUp;


namespace UnitTestStockItUp
{
    [TestClass]
    public class CatalogTest
    {
        [TestMethod]
        public void CatalogRead()
        {
            //Arrange
            List<Product> productlist = Catalog<Product>.Instance.ReadAll().Result;


            //Act
            List<Product> TheList = Catalog<Product>.Instance.GetList;

            //Assert
            Assert.AreEqual(productlist.Count, TheList.Count);
        }

        [TestMethod]
        public async void CatalogCreate()
        {
            //Arrange
            List<Product> productlist1 = Catalog<Product>.Instance.ReadAll().Result;
            Product temProduct = new Product(default(string), default(int));



            //Act
            await Catalog<Product>.Instance.Create(temProduct);
            
            List<Product> productlist2 = Catalog<Product>.Instance.ReadAll().Result;

            //Assert
            Assert.AreEqual(productlist1.Count+1, productlist2.Count);
        }

        [TestMethod]
        public async void CatalogUpdate()
        {
            //Arrange
            List<Product> productlist1 = Catalog<Product>.Instance.ReadAll().Result;
            Product newProduct = new Product("jacob", default(int));



            //Act
            await Catalog<Product>.Instance.Update(1,newProduct);
            //Assert
            Assert.AreEqual(newProduct.Name, Catalog<Product>.Instance.Read(1).Result.Name);
        }
        [TestMethod]
        public async void CatalogDelete()
        {
            //Arrange
            List<Product> productlist1 = Catalog<Product>.Instance.ReadAll().Result;



            //Act
            await Catalog<Product>.Instance.Delete(1);
            List<Product> productlist2 = Catalog<Product>.Instance.ReadAll().Result;
            //Assert
            Assert.AreEqual(productlist1.Count - 1, productlist2.Count);
        }
    }
}
