﻿using System;
using StockItUp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStockItUp
{
    [TestClass]
    public class SupplierUnitTest
    {
        [TestMethod]
        public void TestConstructorWebsite()
        {
            //Arrange
            Supplier s1;

            //Act
            s1 = new Supplier("Supplier1", "www.hejmeddig.dk");

            //Assert
            Assert.AreEqual(s1.Website.Contains("www."), true, "Supplier website dosent have www.");


            ////////////////////////////www no longer necessary//////////////////////
        }

        [TestMethod]
        public void TestConstructorId()
        {
            //Arrange
            Supplier s1;
            Supplier s2;
            Supplier s3;
            Supplier s4;
            Supplier s5;

            //Act
            s1 = new Supplier("Supplier1", "kontakt@1");
            s2 = new Supplier("Supplier2", "kontakt@2");
            s3 = new Supplier("Supplier3", "kontakt@3");
            s4 = new Supplier("Supplier4", "kontakt@4");
            s5 = new Supplier("Supplier5", "kontakt@5");

            //Assert
            Assert.AreEqual(s2.Id+1, s3.Id, "Id dosent add up automaticly");
        }
    }
}
