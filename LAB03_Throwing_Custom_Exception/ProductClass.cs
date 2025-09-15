using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03_Throwing_Custom_Exception
{
    internal class ProductClass
    {
        private int _Quantity;
        private double _SellingPrice;
        private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;

        public ProductClass(string ProductName, string Category, string MfgDate, string ExpDate, 
            double Price, int Quantity, string Description) 
        {
            this._Quantity = Quantity;
            this._SellingPrice = Price;
            this._ProductName = ProductName;
            this._Category = Category;
            this._ManufacturingDate = MfgDate;
            this._ExpirationDate = ExpDate;
            this._Description = Description;
        }

        public string ProductName 
        {
            get { return this._ProductName; }
            set { this._ProductName = value; }
        }

        public string Category
        {
            get { return this._Category; }
            set { this._Category = value; }
        }

        public string ManufacturingDate
        {
            get { return this._ManufacturingDate; }
            set { this._ManufacturingDate = value; }
        }

        public
    }
}
