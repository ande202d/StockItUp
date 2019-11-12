using System;
using StockItUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockItUp.Model;

namespace UnitTestStockItUp
{
    [TestClass]
    public class LocationUnitTest
    {
        [TestMethod]
        public void TestConstructor_Id()
        {
            //Arrange
            Location l1;
            Location l2;
            Location l3;
            Location l4;
            Location l5;

            //Act
            Store s = new Store("store1", "adresse1");

            l1 = new Location(s,"1");
            l2 = new Location(s,"2");
            l3 = new Location(s,"3");
            l4 = new Location(s,"4");
            l5 = new Location(s,"5");
        
            //Assert
            Assert.AreEqual(l2.Id+1, l3.Id, "Id dosent add up automaticly");
        }
    }
}
