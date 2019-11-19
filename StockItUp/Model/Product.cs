﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Persistency;

namespace StockItUp.Model
{
    public class Product
    {
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        private int _amountPerBox;
        private Supplier _mySupplier;

        #region Constructors
        public Product(string name, int amountPerBox, Supplier Supplier)
        {
            _id = _idCounter;
            _idCounter++;

            _name = name;
            _amountPerBox = amountPerBox;
            _mySupplier = Supplier;
        }

        public Product(string name, int amountPerBox)
        {
            _id = _idCounter;
            _idCounter++;

            _name = name;
            _amountPerBox = amountPerBox;
        }

        public Product()
        {
        }
        #endregion

        #region Properties
        public Supplier MySupplier
        {
            get
            {
                if (Supplier==null)
                {
                    return null;
                }

                
                return Catalog<Supplier>.Instance.Read(Supplier.Value).Result;

            }
            set { _mySupplier = value; }
        }

        public int? Supplier { get; set; }

        public int AmountPerBox
        {
            get { return _amountPerBox; }
            set { _amountPerBox = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        } 
        #endregion

    }
}
