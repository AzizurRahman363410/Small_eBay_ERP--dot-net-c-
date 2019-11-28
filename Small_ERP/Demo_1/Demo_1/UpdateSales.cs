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
    public partial class UpdateSales : Form
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
        public int id;
        string category;
        string shipping;
        public UpdateSales()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            cmbAddItem();
            cmbShippingItem();
        }

        private void backHrBut_Click(object sender, EventArgs e)
        {
            SalesDeshBoard salesDeshBoard = new SalesDeshBoard("no");
            salesDeshBoard.Show();
            this.Close();
        }
        private void load(int id)
        {

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            OleDbDataReader reader;
            //get login Data
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM SaleCustomer WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtCustomerId.Text = reader["ID"].ToString();
                    txtCustomerName.Text = reader["CustomerName"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
            }
            //get login Data
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM SaleShipping WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtAwb.Text = reader["AWB"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
            }
            //get Employee Data
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM SaleProduct  WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtProductName.Text = reader["ProductName"].ToString();
                    txtQuantity.Text = reader["Quantity"].ToString();
                    txtCost.Text = reader["Cost"].ToString();        
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
            }
            //get Address Data
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM SaleAddress  WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtHouse.Text = reader["House"].ToString();
                    txtStreet.Text = reader["Street"].ToString();
                    txtArea.Text = reader["Area"].ToString();
                    txtPost.Text = reader["Post"].ToString();
                    txtCity.Text = reader["City"].ToString();
                    txtState.Text = reader["State"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(txtEditId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Int Convert" + ex.Message);
            }

            if (id > 0)
            {
                load(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool updateShipping(int id)
        {

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            //Check Update Database User
            try
            {
                string query = "Update Shipping Set [ShippingDate]=@shippingDate, [AWB]=@aWB, [ShippingType]=@shippingType Where [CustomerId]=@id";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@shippingDate", dateShipping.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@aWB", txtAwb);
                cmd.Parameters.AddWithValue("@shippingType", shipping);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return false;
            }
        }

        private bool updateCustiomer(int id)
        {

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isCustomerValid())
            {
                MessageBox.Show("Job Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                string query = "Update SaleCustomer Set [InvDate]=@invDate, [CustomerName]=@customerName, [Phone]=@phone, [Email]=@email where [Id]=@id";
                OleDbCommand cmd = new OleDbCommand(query, conn); 
                cmd.Parameters.AddWithValue("@invDate", dateInvoice.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@customerName", txtCustomerName);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return false;
            }
        }

        private bool updateProduct(int id)
        {

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isProductValid())
            {
                MessageBox.Show("Employee Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                string query = "Update SaleProduct Set [Category]=@category,[ProductName]=@productName,[Quantity]=@quantity,[Cost]=@cost where [Id]=@id";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@productName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@cost", txtCost.Text);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return false;
            }

        }

        private bool updateAddress(int id)
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
                string query = "Update SaleAddress Set [House]=@house,[Street]=@street,[Area]=@area,[Post]=@post,[City]=@city,[State]=@state where [Id] = @id";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@house", txtHouse.Text);
                cmd.Parameters.AddWithValue("@street", txtStreet.Text);
                cmd.Parameters.AddWithValue("@area", txtArea.Text);
                cmd.Parameters.AddWithValue("@post", txtPost.Text);
                cmd.Parameters.AddWithValue("@city", txtCity.Text);
                cmd.Parameters.AddWithValue("@state", txtStreet.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return false;
            }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                updateAddress(id);
                updateCustiomer(id);
                updateProduct(id);
                updateAddress(id);
                MessageBox.Show("Update Successful : ");

            }
        }
    }
}
