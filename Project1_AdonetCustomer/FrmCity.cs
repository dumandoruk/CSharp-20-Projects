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
    public partial class FrmCity : Form
    {
        public FrmCity()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=KASISKI;Initial Catalog=DbCustomer;Integrated Security=True; Encrypt=False";

        private void ListDatas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TblCity";
                using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null; // sahte seçimleri temizle
            ApplyButtonState();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            ListDatas();
            ApplyButtonState();   // ← 
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "insert into TblCity (CityName,CityCountry) values (@CityName,@CityCountry)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityName", txtCityName.Text);
                    command.Parameters.AddWithValue("@CityCountry", txtCountry.Text);
                    command.ExecuteNonQuery();
                }
            }
            ListDatas();
            txtCityName.Text = "";
            txtCountry.Text = "";
            ApplyButtonState();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            if (!int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out int cityId))
            {
                MessageBox.Show("Invalid City Id.");
                return;
            }
            var ask = MessageBox.Show(
            $"Are you sure you want to delete City #{cityId}?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (ask != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand("DELETE FROM TblCity WHERE CityId= @CityId", connection))
                {
                    command.Parameters.AddWithValue("@CityId", cityId);

                    connection.Open();
                    int affected = command.ExecuteNonQuery();
                    if (affected > 0)
                        MessageBox.Show("City deleted successfully.");
                    else
                        MessageBox.Show("City not found or already deleted.");

                }
                ListDatas();
                dataGridView1.ClearSelection();
                txtCityName.Text = "";
                txtCountry.Text = "";
                txtCityName.Focus();
                ApplyButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }


        }

        private void ApplyButtonState()
        {
            bool selected = dataGridView1.CurrentRow != null;
            bool hasFields = !string.IsNullOrWhiteSpace(txtCityName.Text)
                          || !string.IsNullOrWhiteSpace(txtCountry.Text);

            // Search her zaman açık
            btnSearch.Enabled = true;

            if (selected)
            {
                // Seçimdeyken: Add kapalı, diğerleri açık
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                // Seçim yokken: Add açık, Update/Delete kapalı
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnClear.Enabled = hasFields; // alanlarda yazı varsa Clear aç
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtCityId.Text = row.Cells["CityId"].Value.ToString();
                txtCityName.Text = row.Cells["CityName"].Value.ToString();
                txtCountry.Text = row.Cells["CityCountry"].Value.ToString();
            }

            ApplyButtonState(); // ← bunu bırak, alttaki el ile setleri SİL

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE TblCity set CityName=@CityName, CityCountry=@CityCountry where CityId=@CityId";

                using (SqlCommand comman = new SqlCommand(query, connection))
                {
                    comman.Parameters.AddWithValue("@CityId", txtCityId.Text);
                    comman.Parameters.AddWithValue("@CityName", txtCityName.Text);
                    comman.Parameters.AddWithValue("@CityCountry", txtCountry.Text);
                    comman.ExecuteNonQuery();
                }
            }

            ListDatas();
            txtCityName.Text = "";
            txtCountry.Text = "";
            ApplyButtonState();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM TblCity WHERE CityName=@CityName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityName", txtCityName.Text);
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["FrmMap"].Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            txtCityId.Text = ""; txtCityName.Text = ""; txtCountry.Text = "";
            txtCityName.Focus();

            ApplyButtonState(); // ← ekle
        }
        
        private void txtCityName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }


    }
}
