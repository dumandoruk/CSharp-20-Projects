using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_EfDbFirstProduct
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }
        Db2Projects20Entities db = new Db2Projects20Entities();
        void ProductList()
        {
            dataGridView1.DataSource = db.TblProducts.ToList();
        }
        private void FrmProducts_Load(object sender, EventArgs e)
        {
            ProductList();
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
            comboBox1.DataSource = db.TblCategories.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblProduct tblProduct = new TblProduct();
            tblProduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
            tblProduct.ProductName = txtProductName.Text;
            tblProduct.ProductStock = short.Parse(txtProductStock.Text);
            tblProduct.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            db.TblProducts.Add(tblProduct);
            db.SaveChanges();
            ProductList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var value = db.TblProducts.Find(int.Parse(txtProductId.Text));
            db.TblProducts.Remove(value);
            db.SaveChanges();
            ProductList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var value = db.TblProducts.Find(int.Parse(txtProductId.Text));
            value.ProductName = txtProductName.Text;
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductStock = short.Parse(txtProductStock.Text);
            value.CategoryId = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            ProductList();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var values = db.TblProducts.Where(x => x.ProductName == txtProductName.Text).ToList();
            dataGridView1.DataSource = values;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values=db.TblProducts.Join(db.TblCategories,ProductList => ProductList.CategoryId, 
                CategoryList => CategoryList.CategoryId, 
                (ProductList, CategoryList) => new
                {
                    ProductId=ProductList.ProductId,
                    ProductName=ProductList.ProductName,
                    ProductPrice=ProductList.ProductPrice,
                    ProductStock = ProductList.ProductStock,
                    CategoryName = CategoryList.CategoryName
                }).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
