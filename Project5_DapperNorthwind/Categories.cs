using Dapper;
using Project5_DapperNorthwind.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Project5_DapperNorthwind
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Db5Project;Integrated Security=True");
        private async void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Categories";
            var values = await connection.QueryAsync<ResultCategoryDto>(query);
            dataGridView1.DataSource = values;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Categories (CategoryName,Description) Values (@P1,@P2)";
            var parameteres = new DynamicParameters();
            parameteres.Add("@P1", txtName.Text);
            parameteres.Add("@P2", txtDescription.Text);
            await connection.ExecuteAsync(sql, parameteres);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value?.ToString();
                txtName.Text = row.Cells[1].Value?.ToString();
                txtDescription.Text = row.Cells[2].Value?.ToString();
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string query= "Delete from Categories where CategoryId=@P1";
            var parameters = new DynamicParameters();
            parameters.Add("@P1", txtId.Text);
            await connection.ExecuteAsync(query, parameters);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string query = "Update Categories set CategoryName=@P1,Description=@P2 where CategoryID=@CategoryId";
            var parameters=new DynamicParameters();
            parameters.Add("@P1",txtName.Text);
            parameters.Add("@P2", txtDescription.Text);
            parameters.Add("@CategoryId", txtId.Text);
            await connection.ExecuteAsync(query, parameters);
        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenStatistics_Click(object sender, EventArgs e)
        {
            FrmStatistics frm = new FrmStatistics();
            frm.Show();
        }

        private void btnOpenProducts_Click(object sender, EventArgs e)
        {
            Products frm = new Products();
            frm.Show();
        }
    }
}
