using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Project1_AdonetCustomer
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=KASISKI;Initial Catalog=DbCustomer;Integrated Security=True; Encrypt=False";

        private void ListDatas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT c.CustomerId,
                   c.CustomerName,
                   c.CustomerSurname,
                   c.CustomerBalance,
                   c.CustomerStatus,
                   c.CustomerCity,   -- << Id burada
                   ci.CityName
            FROM TblCustomer c
            INNER JOIN TblCity ci ON ci.CityId = c.CustomerCity";

                using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void ComboBoxFill()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand comman = new SqlCommand(
                "Select CityId,CityName From TblCity ORDER BY CityName", connection))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(comman))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCity.DataSource = dt;
                    cmbCity.DisplayMember = "CityName";
                    cmbCity.ValueMember = "CityId";
                    cmbCity.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbCity.SelectedIndex = -1; // İlk başta hiçbir şey seçili olmasın
                }
            }

        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            ComboBoxFill();
            ListDatas();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "insert into TblCustomer (CustomerName,CustomerSurname,CustomerCity,CustomerBalance,CustomerStatus) values (@CustomerName,@CustomerSurname,@CustomerCity,@CustomerBalance,@CustomerStatus)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    command.Parameters.AddWithValue("@CustomerSurname", txtCustomerSurname.Text);
                    command.Parameters.AddWithValue("@CustomerCity", cmbCity.SelectedValue);
                    command.Parameters.AddWithValue("@CustomerBalance", txtCustomerBalance.Text);
                    if (radioTrue.Checked)
                    {
                        command.Parameters.AddWithValue("@CustomerStatus", true);
                    }
                    if (radioFalse.Checked)
                    {
                        command.Parameters.AddWithValue("@CustomerStatus", false);
                    }
                    command.ExecuteNonQuery();
                }
            }
            ListDatas();
            txtCustomerId.Text = "";
            txtCustomerName.Text = "";
            txtCustomerName.Text = "";
            txtCustomerSurname.Text = "";
            txtCustomerBalance.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["FrmMap"].Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM TblCustomer WHERE CustomerId = @CustomerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", dataGridView1.CurrentRow.Cells[0].Value);
                    command.ExecuteNonQuery();
                }
            }
            ListDatas();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // başlık kısmı değilse
            {
                var row = dataGridView1.Rows[e.RowIndex];

                txtCustomerId.Text = row.Cells["CustomerId"].Value?.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value?.ToString();
                txtCustomerSurname.Text = row.Cells["CustomerSurname"].Value?.ToString();
                txtCustomerBalance.Text = row.Cells["CustomerBalance"].Value?.ToString();
                bool status = false;
                if (row.Cells["CustomerStatus"]?.Value != DBNull.Value && row.Cells["CustomerStatus"]?.Value != null)
                    status = Convert.ToBoolean(row.Cells["CustomerStatus"].Value);
                radioTrue.Checked = status;
                radioFalse.Checked = !status;

                if (row.Cells["CustomerCity"].Value != DBNull.Value && row.Cells["CustomerCity"]?.Value != null)
                {
                    cmbCity.SelectedValue = Convert.ToInt32(row.Cells["CustomerCity"].Value);
                }
                else
                {
                    cmbCity.SelectedIndex = -1; // Eğer CityId boş ise, ComboBox'ta hiçbir şey seçili olmasın
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE TblCustomer
                         SET CustomerName=@CustomerName,
                             CustomerSurname=@CustomerSurname,
                             CustomerCity=@CustomerCity,
                             CustomerBalance=@CustomerBalance,
                             CustomerStatus=@CustomerStatus
                         WHERE CustomerId=@CustomerId";

                using (SqlCommand comman = new SqlCommand(query, connection))
                {
                    comman.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    comman.Parameters.AddWithValue("@CustomerSurname", txtCustomerSurname.Text);
                    comman.Parameters.AddWithValue("@CustomerBalance", txtCustomerBalance.Text);
                    if (cmbCity.SelectedValue == null)
                    {
                        MessageBox.Show("Lütfen bir şehir seçin.");
                        return;
                    }
                    comman.Parameters.AddWithValue("@CustomerCity", (int)cmbCity.SelectedValue);

                    if (!int.TryParse(txtCustomerId.Text, out int id))
                    {
                        MessageBox.Show("Geçerli bir müşteri seçin.");
                        return;
                    }
                    comman.Parameters.AddWithValue("@CustomerId", id);

                    bool status = radioTrue.Checked; // true/false
                    comman.Parameters.AddWithValue("@CustomerStatus", status);

                    comman.ExecuteNonQuery();
                }
            }

            ListDatas();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select CustomerId,CustomerName,CustomerSurname,CustomerBalance,CustomerStatus,CityName From TblCustomer Inner Join TblCity On TblCity.CityId=TblCustomer.CustomerCity Where CustomerName=@CustomerName", connection);
                command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                SqlDataAdapter adapter= new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }
    }
}
