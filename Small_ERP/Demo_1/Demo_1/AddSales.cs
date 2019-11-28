using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1
{
    public partial class AddSales : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
          int nLeftRect, // x-coordinate of upper-left corner 
          int nTopRect, // y-coordinate of upper-left corner 
          int nRightRect, // x-coordinate of lower-right corner 
          int nBottomRect, // y-coordinate of lower-right corner 
          int nWidthEllipse, // height of ellipse 
          int nHeightEllipse // width of ellipse 
          );
        string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mohammud\Documents\DB\Database1.accdb;
                                     Persist Security Info = False;";
        string category;
        string shipping;
        public AddSales()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            cmbAddItem();
            cmbShippingItem();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backHrBut_Click(object sender, EventArgs e)
        {
            SalesDeshBoard salesDeshBoard = new SalesDeshBoard("no");
            salesDeshBoard.Show();
            this.Close();
        }
        private bool isAddressValid()
        {
            if (txtHouse.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtStreet.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtArea.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtPost.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtCity.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtState.Text.Trim().Equals(""))
            {
                return false;
            }
            return true;
        }
        private bool isProductValid()
        {
            if (txtId.Text.Trim().Equals(""))
            {
                return false;
            }
            if (cmbCategory.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtProductName.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtCost.Text.Trim().Equals(""))
            {
                return false;
            }
            
            return true;
        }
        private bool isCustomerValid()
        {
            if (txtCustomerId.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtCustomerName.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtPhone.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtEmail.Text.Trim().Equals(""))
            {
                return false;
            }

            return true;
        }
        private void cmbAddItem()
        {
            cmbCategory.Items.Add("PC");
            cmbCategory.Items.Add("RAM");
            cmbCategory.Items.Add("Processor");
            cmbCategory.Items.Add("Monitor");
            cmbCategory.Items.Add("MotherBoard");
            cmbCategory.Items.Add("Cooler");
            cmbCategory.Items.Add("Casing");
            cmbCategory.Items.Add("Power Supply");
            cmbCategory.Items.Add("Laptop");
        }
        private void cmbShippingItem()
        {
            cmbshippingOpt.Items.Add("DHL");
            cmbshippingOpt.Items.Add("AMAZON");
            cmbshippingOpt.Items.Add("SHL");           
        }

        private void cmbshippingOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbshippingOpt.SelectedIndex;
            shipping = cmbshippingOpt.Items[index].ToString();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbCategory.SelectedIndex;
            category = cmbCategory.Items[index].ToString();
        }
        private bool insertSealCustomer()
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isCustomerValid())
            {
                MessageBox.Show("Customer Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            // Check Databse Validation
            try
            {
                int id = 0;
                OleDbDataReader reader;
                OleDbCommand command = new OleDbCommand("SELECT [ID] FROM SaleCustomer WHERE [ID] = @id ", conn);
                command.Parameters.AddWithValue("@id", txtCustomerId.Text);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                    if (id > 0)
                    {
                        MessageBox.Show("Invalid Customer Id User Name Already exits : ");
                        return false;
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return false;
            }
            //Insert Into database
            try
            {
                string query = "Insert into SaleCustomer ([Id],[InvDate],[CustomerName],[Phone],[Email]) values (@id,@invDate,@customerName,@phone,@email)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtCustomerId.Text);
                cmd.Parameters.AddWithValue("@invDate", dateInvoice.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@customerName", txtCustomerName);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Product failer : " + ex.Message);
                return false;
            }
        }
        private bool insertSaleShipping()
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isProductValid())
            {
                MessageBox.Show("Product Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                string query = "Insert into SaleShipping ([ShippingDate],[AWB],[ShippingType],[CustomerId]) values (@shippingDate,@aWB,@shippingType,@customerId)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@shippingDate", dateShipping.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@aWB", txtAwb);
                cmd.Parameters.AddWithValue("@shippingType", shipping);
                cmd.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("SaleShipping failer : " + ex.Message);
                return false;
            }
        }
        private bool insertSaleProduct()
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isProductValid())
            {
                MessageBox.Show("Product Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                int id = 0;
                OleDbDataReader reader;
                OleDbCommand command = new OleDbCommand("SELECT [ID] FROM Product WHERE [ID] = @id ", conn);
                command.Parameters.AddWithValue("@id", txtId.Text);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                    if (id > 0)
                    {
                        MessageBox.Show("Customer Product Not exits : ");
                        return false;
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return false;
            }
            try
            {
                string query = "Insert into SaleProduct ([Category],[ProductName],[Quantity],[Cost],[CustomerId]) values (@category,@productName,@quantity,@cost,@CustomerId)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@productName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@cost", txtCost.Text);
                cmd.Parameters.AddWithValue("@customerId", txtCustomerId.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Product failer : " + ex.Message);
                return false;
            }
        }
        private bool insertSalesAddress()
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isAddressValid())
            {
                MessageBox.Show("Address Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                string query = "Insert into SaleAddress ([House],[Street],[Area],[Post],[City],[State],[CustomerId]) values (@house,@street,@area,@post,@city,@state,@customerId)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@house", txtHouse.Text);
                cmd.Parameters.AddWithValue("@street", txtStreet.Text);
                cmd.Parameters.AddWithValue("@area", txtArea.Text);
                cmd.Parameters.AddWithValue("@post", txtPost.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@state", txtStreet.Text);
                cmd.Parameters.AddWithValue("@customerId", txtCustomerId.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Address failer : " + ex.Message);
                return false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (insertSaleProduct())
            {
                insertSealCustomer();
                insertSaleShipping();
                insertSalesAddress();
                MessageBox.Show("sales Product SuccessFul : ");
            }
            else
            {
                MessageBox.Show("sales Not Product SuccessFul : ");
            }
           
        }
    }
}
