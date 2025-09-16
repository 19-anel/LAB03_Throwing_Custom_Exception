using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB03_Throwing_Custom_Exception
{
    public partial class frmAddProduct : Form
    {
        private int _Quantity;
        private double _SellingPrice;
        private string _ProductName, _Category, _ManufacturingDate, _ExpirationDate, _Description;
        private BindingSource showProductList;
        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        public class NumberFormatException : Exception
        {
            public NumberFormatException(string message) : base(message) { }
        }

        public class StringFormatException : Exception
        {
            public StringFormatException(string message) : base(message) { }
        }

        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string message) : base(message) { }
        }


        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory =
            {
              "Beverages",
              "Bread/Bakery",
              "Canned/Jarred Goods",
              "Dairy",
              "Frozen Goods",
              "Meat",
              "Personal Care",
               "Other"
            };

            foreach (string item in ListOfProductCategory)
            {
                cbCategory.Items.Add(item);
            }
        }

        private string Product_Name(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new StringFormatException("Product Name cannot be empty.");
            return input;
        }

        private int Quantity(string input)
        {
            if (!int.TryParse(input, out int result))
                throw new NumberFormatException("Quantity must be a valid number.");
            return result;
        }

        private double SellingPrice(string input)
        {
            if (!double.TryParse(input, out double result))
                throw new CurrencyFormatException("Selling Price must be a valid currency/number.");
            return result;
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _ManufacturingDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpirationDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellingPrice = SellingPrice(txtSellPrice.Text);

                showProductList.Add(new ProductClass(_ProductName, _Category, _ManufacturingDate, _ExpirationDate,
                   _SellingPrice, _Quantity, _Description));

                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "String Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Currency Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Console.WriteLine("Add Product process executed.");
            }
        }
    }

}
