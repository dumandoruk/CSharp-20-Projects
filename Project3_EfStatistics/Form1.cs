using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3_EfStatistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbProject3Entities db = new DbProject3Entities();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Toplam Kategori Sayısı
            int categoryCount=db.Tbl_Category.Count();
            lblCategoryCount.Text = categoryCount.ToString();

            //Toplam Ürün Sayısı
            int productCount=db.Tbl_Product.Count();
            lblProductCount.Text = productCount.ToString();

            //Toplam Müşteri Sayısı
            int customerCount=db.Tbl_Customer.Count();
            lblCustomerCount.Text = customerCount.ToString();

            //Sipariş Sayısı
            int orderCount=db.Tbl_Order.Count();
            lblOrderCount.Text = orderCount.ToString();

        }
    }
}
