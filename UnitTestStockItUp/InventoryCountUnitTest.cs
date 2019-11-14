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
            ic1 = new InventoryCount((new Location(new Store("store", "adress"), "location")));
            ic2 = new InventoryCount((new Location(new Store("store", "adress"), "location")));
            ic3 = new InventoryCount((new Location(new Store("store", "adress"), "location")));
            ic4 = new InventoryCount((new Location(new Store("store", "adress"), "location")));
            ic5 = new InventoryCount((new Location(new Store("store", "adress"), "location")));
            
            //Assert
            Assert.AreEqual(ic2.Id+1, ic3.Id, "Id dosent add up automaticly");
        }
    }
}
