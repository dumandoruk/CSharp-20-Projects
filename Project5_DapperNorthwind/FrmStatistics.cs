using Dapper;
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

namespace Project5_DapperNorthwind
{
    public partial class FrmStatistics : Form
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Db5Project;Integrated Security=True";
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private async void FrmStatistics_Load(object sender, EventArgs e)
        {
            await LoadStatistics();
        }

        private async Task LoadStatistics()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                lblCategoryCount.Text = await connection.ExecuteScalarAsync<string>("Select Count(*) From Categories");

                lblProductCount.Text = await connection.ExecuteScalarAsync<string>("Select Count(*) From Products");

                string queryExpensive = "Select Top 1 ProductName From Products Order By UnitPrice Desc";
                lblMaxPriceProduct.Text = await connection.ExecuteScalarAsync<string>(queryExpensive);

                string queryMinStock = "Select Top 1 ProductName From Products Order By UnitsInStock Asc";
                lblMinStockProduct.Text = await connection.ExecuteScalarAsync<string>(queryMinStock);
            }
        }

        private void btnOpenProduct_Click(object sender, EventArgs e)
        {
            Products frm = new Products();
            frm.Show();
        }

        private void btnOpenCategory_Click(object sender, EventArgs e)
        {
            Categories frm = new Categories();
            frm.Show();
        }
    }
}
