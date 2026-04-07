using Project4_EfCodeFirstMovie.Context;
using Project4_EfCodeFirstMovie.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4_EfCodeFirstMovie
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            using (var db = new MovieContext())
            {
                var values = db.Categories.ToList();
                dataGridView1.DataSource = values;
                dataGridView1.Columns["Movies"].Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoryId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCategoryName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            using (var db = new MovieContext())
            {
                int id = int.Parse(txtCategoryId.Text);
                var value = db.Categories.Find(id);
                db.Categories.Remove(value);
                db.SaveChanges();
                MessageBox.Show("Category Deleted");
                btnCategoryList.PerformClick();
            }
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            using (var db = new MovieContext())
            {
                Category category = new Category();
                category.CategoryName = txtCategoryName.Text;
                db.Categories.Add(category);
                db.SaveChanges();
                MessageBox.Show("Category Added");
                btnCategoryList.PerformClick();
            }
        }

        private void btnCategoryUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryId.Text))
            {
                MessageBox.Show("Lütfen önce listeden bir kategori seçin!");
                return;
            }
            using (var db = new MovieContext())
            {
                int id = int.Parse(txtCategoryId.Text);
                var value = db.Categories.Find(id);
                value.CategoryName = txtCategoryName.Text;
                db.SaveChanges();
                MessageBox.Show("Category Updated");
                btnCategoryList.PerformClick();
            }
        }
    }
}
