using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gbxSearch_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            ListCategories();
            ListProducts();
        }

        private void ListProducts()
        {
            using (NorthwindContext contect = new NorthwindContext())
            {
                dgwProduct.DataSource = contect.Products.ToList();
            }
        }

        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext contect = new NorthwindContext())
            {
                dgwProduct.DataSource = contect.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
        }

        private void ListProductsByProductName(string key)
        {
            using (NorthwindContext contect = new NorthwindContext())
            {
                dgwProduct.DataSource = contect.Products.Where(p => p.ProductName.ToLower().Contains(key.ToLower())).ToList();
            }
        }

        private void ListCategories()
        {
            using (NorthwindContext contect = new NorthwindContext())
            {
                cbxCategory.DataSource = contect.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch 
            {

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = tbxSearch.Text;
            if (string.IsNullOrEmpty(key))
            {
                ListProducts();
            }
            else
            {
                ListProductsByProductName(tbxSearch.Text);
            }
        }
    }
}
