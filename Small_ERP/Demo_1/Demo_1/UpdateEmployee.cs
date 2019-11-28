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
    public partial class UpdateEmployee : Form
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
        public UpdateEmployee()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (id > 0)
            {
                load(id);
            }
            
        }
        
        private void load(int id)
        {
            
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            OleDbDataReader reader;
            //get login Data
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM Login WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtUsername.Text = reader["User"].ToString();
                    txtPassword.Text = reader["Pass"].ToString();
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
                OleDbCommand command = new OleDbCommand("SELECT * FROM Job  WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtDepartment.Text = reader["Department"].ToString();
                    txtTitle.Text = reader["Title"].ToString();
                    txtSalary.Text = reader["Salary"].ToString();
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
                OleDbCommand command = new OleDbCommand("SELECT * FROM Employee  WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtNid.Text = reader["NID"].ToString();
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
                OleDbCommand command = new OleDbCommand("SELECT * FROM Address  WHERE [ID] = @id", conn);
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

        private bool isLoginValid()
        {
            if (txtUsername.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtPassword.Text.Trim().Equals(""))
            {
                return false;
            }
            return true;
        }

        private bool isJobValid()
        {
            if (txtDepartment.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtTitle.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtSalary.Text.Trim().Equals(""))
            {
                return false;
            }
            return true;
        }

        private bool isEmployeeValid()
        {
            if (txtName.Text.Trim().Equals(""))
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
            if (txtNid.Text.Trim().Equals(""))
            {
                return false;
            }
            return true;
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

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private bool updateLogIn(int id)
        {
            
            OleDbConnection conn = new OleDbConnection(ConnectionString);
           
            // Check input Validation
            if (!isLoginValid())
            {
                MessageBox.Show("User & Pass Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            //Check Update Database User
            try
            {
                string query = "Update Login Set [User]=@user, [Pass]=@pass Where [Id]=@id";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
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

        private bool updateJob(int id)
        {
            
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isJobValid())
            {
                MessageBox.Show("Job Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                string query = "Update Job Set [Department]=@depart, [Title]=@title, [Salary]=@salary, [Join_Date]=@date where [Id]=@id";
                OleDbCommand cmd = new OleDbCommand(query, conn);
               
                cmd.Parameters.AddWithValue("@depart", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@date", dateOfJoin.Value.ToShortDateString());
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

        private bool updateEmployee(int id)
        {
            
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isEmployeeValid())
            {
                MessageBox.Show("Employee Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                string query = "Update Employee Set [Name]=@name,[Phone]=@phone,[Email]=@email,[NID]=@nid,[DOB]=@dob where [Id]=@id";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@nid", txtNid.Text);
                cmd.Parameters.AddWithValue("@dob", dateDOB.Value.ToShortDateString());
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
                string query = "Update Address Set [House]=@house,[Street]=@street,[Area]=@area,[Post]=@post,[City]=@city,[State]=@state where [Id] = @id";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                updateLogIn(id);
                updateJob(id);
                updateEmployee(id);
                updateAddress(id);
                MessageBox.Show("Update Successful : ");
                
            }
           
        }

        private void backHrBut_Click(object sender, EventArgs e)
        {
            HrDeshboard hrDeshboard = new HrDeshboard("no");
            hrDeshboard.Show();
            this.Close();
        }
    }

}
