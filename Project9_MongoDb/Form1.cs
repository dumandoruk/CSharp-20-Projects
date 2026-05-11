using Project9_MongoDb.Entities;
using Project9_MongoDb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project9_MongoDb
{
    public partial class MongoDB : Form
    {
        public MongoDB()
        {
            InitializeComponent();
        }

        OrderOperation orderOperation = new OrderOperation();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                City = txtCity.Text,
                CustomerName = txtCustomerName.Text,
                District = TxtDistrict.Text,
                TotalPrice = decimal.Parse(txtTotalPrice.Text),
                OrderID = txtOrderId.Text
            };

            orderOperation.AddOrder(order);
            MessageBox.Show("Added Successfly");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Order> order = orderOperation.GetAllOrders();
            dataGridView1.DataSource = order;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOrderId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtOrderId.Text;
            if (!string.IsNullOrEmpty(id))
            {
                orderOperation.DeleteOrder(id);
                MessageBox.Show("Deleted your order");
                btnList_Click(sender, e);
                txtOrderId.Clear();
            }
            else
            {
                MessageBox.Show("Please select an order to delete.");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updatedOrder = new Order
            {
                Id = txtOrderId.Text,
                OrderID = txtOrderId.Text,
                CustomerName = txtCustomerName.Text,
                City = txtCity.Text,
                District = TxtDistrict.Text,
                TotalPrice = decimal.Parse(txtTotalPrice.Text)
            };

            orderOperation.UpdateOrder(updatedOrder);

            MessageBox.Show("Order uptated successfuly!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnList_Click(sender, e);
        }
    }
}
