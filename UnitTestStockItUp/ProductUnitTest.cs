using System;
using System.Collections.Generic;
using StockItUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockItUp.Model;
using StockItUp.Persistency;

namespace UnitTestStockItUp
{
    [TestClass]
    public class ProductUnitTest
    {
        [TestMethod]
        public void TestConstructor_Id()
        {
            //Arrange
            Product p1;
            Product p2;
            Product p3;
            Product p4;
            Product p5;

            //Act
            p1 = new Product("1", 1);
            p2 = new Product("2", 2, new Supplier("s1", "www.hejmeddig.dk"));
            p3 = new Product("3", 3);
            p4 = new Product("4", 4, new Supplier("s2", "www.hejmeddigv2.dk"));
            p5 = new Product("5", 5);

            //Assert
            Assert.AreEqual(p2.Id+1, p3.Id, "Id dosent add up automaticly");
        }

        [TestMethod]
        public void TestConstructor_AmountPerBox()
        {
            //Arrange
            Product p1;

            //Act
            p1 = new Product("Coca Cola", 1);

            //Assert
            Assert.AreEqual(true, p1.AmountPerBox>0, "amount per box cant be 0 or bellow");
        }
    }
}
