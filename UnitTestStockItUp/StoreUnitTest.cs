using System;
using StockItUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockItUp.Model;

namespace UnitTestStockItUp
{
    [TestClass]
    public class StoreUnitTest
    {
        [TestMethod]
        public void TestConstructor_Id()
        {
            //Arrange
            Store s1;
            Store s2;
            Store s3;
            Store s4;
            Store s5;

            //Act
            s1 = new Store("storeName1", "adress1");
            s2 = new Store("storeName2", "adress2");
            s3 = new Store("storeName3", "adress3");
            s4 = new Store("storeName4", "adress4");
            s5 = new Store("storeName5", "adress5");
        
            //Assert
            Assert.AreEqual(s2.Id+1, s3.Id, "Id dosent add up automaticly");
        }
    }
}
