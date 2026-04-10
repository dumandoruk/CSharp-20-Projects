using Dapper;
using Project5_DapperNorthwind.Dtos.CategoryDtos;
using Project5_DapperNorthwind.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project5_DapperNorthwind
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Db5Project;Integrated Security=True";

        private async Task ProductList()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "Select ProductID, ProductName, UnitPrice, UnitsInStock, CategoryName " +
                               "From Products Inner Join Categories On Products.CategoryID = Categories.CategoryID";

                var values = await connection.QueryAsync<ResultProductDto>(query);
                dataGridView1.DataSource = values.ToList();
            }
        }

        private async Task LoadCategories()
        {
            string query = "Select CategoryID, CategoryName From Categories";
            using (var connection = new SqlConnection(connectionString))
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                comboBox1.DataSource = values.ToList();
                comboBox1.DisplayMember = "CategoryName";
                comboBox1.ValueMember = "CategoryID";
            }
        }
        private async void Products_Load(object sender, EventArgs e)
        {
            await ProductList();
            await LoadCategories();
        }

        private async void btnList_Click(object sender, EventArgs e)
        {
            await ProductList();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            string query = "Insert Into Products (ProductName, UnitPrice, UnitsInStock, CategoryID) " +
               "Values (@p1, @p2, @p3, @p4)";
            var parameters= new DynamicParameters();
            parameters.Add("@p1",txtProductName.Text);
            parameters.Add("@p2", decimal.Parse(txtProductUnitPrice.Text));
            parameters.Add("@p3", short.Parse(txtProductInStock.Text));
            parameters.Add("@p4",comboBox1.SelectedValue);

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(query, parameters);
                MessageBox.Show("Ürün başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ProductList();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                txtProductId.Text = row.Cells[0].Value?.ToString();
                txtProductName.Text = row.Cells[1].Value?.ToString();
                txtProductUnitPrice.Text = row.Cells[2].Value?.ToString();
                txtProductInStock.Text = row.Cells[3].Value?.ToString();
                comboBox1.Text=row.Cells[4].Value?.ToString();

            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            string query = "Delete From Products Where ProductID=@p1";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", txtProductId.Text);
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(query, parameters);
                MessageBox.Show("Ürün başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ProductList();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "Update Products set ProductName=@P1,UnitPrice=@P2, UnitsInStock=@P3 , CategoryID=@P4 where ProductID=@ProductID";
            var parameters = new DynamicParameters();
            parameters.Add("@P1", txtProductName.Text);
            parameters.Add("@P2", decimal.Parse(txtProductUnitPrice.Text));
            parameters.Add("@P3", short.Parse(txtProductInStock.Text));
            parameters.Add("@P4", comboBox1.SelectedValue);
            parameters.Add("@ProductID", txtProductId.Text);
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(query, parameters);
                MessageBox.Show("Ürün başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await ProductList();
            }
        }
    }
}
