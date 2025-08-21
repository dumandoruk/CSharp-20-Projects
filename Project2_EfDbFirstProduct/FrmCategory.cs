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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        Db2Projects20Entities db = new Db2Projects20Entities();
        void CategoryList()
        {
            dataGridView1.DataSource =db.TblCategories.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TblCategory tblCategory = new TblCategory();
            tblCategory.CategoryName = txtCategoryName.Text;
            db.TblCategories.Add(tblCategory);
            db.SaveChanges();
            CategoryList();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            int id=Convert.ToInt32(txtCategoryId.Text);
            var value = db.TblCategories.Find(id);
            db.TblCategories.Remove(value);
            db.SaveChanges();
            CategoryList();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoryId.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var value=db.TblCategories.Find(id);
            value.CategoryName = txtCategoryName.Text;
            db.SaveChanges();
            CategoryList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmProducts frmProducts = new FrmProducts();
            frmProducts.Show();
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var values=db.TblCategories.Where(x=>x.CategoryName == txtCategoryName.Text).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
