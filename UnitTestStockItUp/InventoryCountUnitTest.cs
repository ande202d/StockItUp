using System;
using System.Collections.Generic;
using StockItUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockItUp.Model;

namespace UnitTestStockItUp
{
    [TestClass]
    public class InventoryCountUnitTest
    {
        [TestMethod]
        public void TestConstructor_Id()
        {
            //Arrange
            InventoryCount ic1;
            InventoryCount ic2;
            InventoryCount ic3;
            InventoryCount ic4;
            InventoryCount ic5;

            //Act
            ic1 = new InventoryCount((new Location(new Store("store1", "adress1"), "location1")), new Dictionary<Product, int>());
        
            //Assert
            //Assert.AreEqual(s2.Id+1, s3.Id, "Id dosent add up automaticly");
        }
    }
}
