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
            int categoryCount = db.Tbl_Category.Count();
            lblCategoryCount.Text = categoryCount.ToString();

            //Toplam Ürün Sayısı
            int productCount = db.Tbl_Product.Count();
            lblProductCount.Text = productCount.ToString();

            //Toplam Müşteri Sayısı
            int customerCount = db.Tbl_Customer.Count();
            lblCustomerCount.Text = customerCount.ToString();

            //Sipariş Sayısı
            int orderCount = db.Tbl_Order.Count();
            lblOrderCount.Text = orderCount.ToString();

            //Toplam Stok
            var totalStock = db.Tbl_Product.Sum(x => x.ProductStock);
            lblTotalStock.Text = totalStock.ToString();

            //Ortalamaa Sipariş Tutarı
            var averageOrderAmount = db.Tbl_Order.Average(x => (decimal?)x.TotalPrice).GetValueOrDefault();
            lblAvgOrderPrice.Text = averageOrderAmount.ToString("C2");

            //En Yüksek Sipariş Tutarı
            var maxOrderAmount = db.Tbl_Order.Max(x => (decimal?)x.TotalPrice).GetValueOrDefault();
            lblMaxOrderPrice.Text = maxOrderAmount.ToString("C2");

            //Kritik Stok Ürün Sayısı
            var criticalStockCount = db.Tbl_Product.Count(x => x.ProductStock <= 5);
            lblCriticalStockCount.Text = criticalStockCount.ToString();

            //En Pahalı Ürün
            var mostExpensiveProduct = db.Tbl_Product.OrderByDescending(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefault();
            lblMostExpensiveProduct.Text = mostExpensiveProduct;

            //En Ucuz Ürün
            var cheapestProduct = db.Tbl_Product.OrderBy(x => x.ProductPrice).Select(x => x.ProductName).FirstOrDefault();
            lblCheapestProduct.Text = cheapestProduct;

            //Ana Kategori Sayısı
            var mainCategoryCount = db.Tbl_Category.Where(x => x.ParentCategoryId == null).Count();
            lblMainCategoryCount.Text = mainCategoryCount.ToString();

            //En Çok Ürünü Olan Kategori
            var cateboryWithMostProducts = db.Tbl_Category
                .Select(x => new
                {
                    CategoryName = x.CategoryName,
                    ProductCount = x.Tbl_Product.Count()
                })
                .OrderByDescending(x => x.ProductCount)
                .FirstOrDefault();
            lblCategoryWithMostProducts.Text = cateboryWithMostProducts.CategoryName;

            //En Çok Sipariş Veren Müşteri
            var topCustomerId = db.Tbl_Order
                .GroupBy(x => x.CustomerId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            if (topCustomerId != null)
            {
                var customerName = db.Tbl_Customer
                    .Where(x => x.CustomerId == topCustomerId)
                    .Select(y => y.CustomerName)
                    .FirstOrDefault();
                lblTopCustomer.Text = customerName;
            }
            else
            {
                lblTopCustomer.Text = "Veri bulunamadı";
            }

            //Aktif Şehir Sayısı
            var activeCityCount = db.Tbl_Customer.Select(x => x.CustomerCity).Distinct().Count();
            lblActiveCityCount.Text = activeCityCount.ToString();

            //En Fazla Stoğu Olan Ürün
            var productWithMostStock = db.Tbl_Product
                .OrderByDescending(x => x.ProductStock)
                .Select(x => x.ProductName)
                .FirstOrDefault();
            lblProductWithMostStock.Text = productWithMostStock;

            //Aydınlatma Kategorisindeki Ürün Sayısı
            var level1SubIds = db.Tbl_Category.Where(x => x.ParentCategoryId == 1).Select(x => x.CategoryId).ToList();
            var level2SubIds = db.Tbl_Category.Where(x => level1SubIds.Contains(x.ParentCategoryId.Value)).Select(x => x.CategoryId).ToList();
            var allLightingCategoryIds = new List<int> { 1 };
            allLightingCategoryIds.AddRange(level1SubIds);
            allLightingCategoryIds.AddRange(level2SubIds);
            int totalLightingProducts = db.Tbl_Product
    .Count(x => x.CategoryId.HasValue && allLightingCategoryIds.Contains(x.CategoryId.Value));

            lblLightingCategoryProducts.Text = totalLightingProducts.ToString();



        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
