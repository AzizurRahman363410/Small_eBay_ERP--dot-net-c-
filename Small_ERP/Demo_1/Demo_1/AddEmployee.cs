using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1
{
    public partial class AddEmployee : Form
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
        public AddEmployee()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backHrBut_Click(object sender, EventArgs e)
        {
            HrDeshboard hrDeshboard = new HrDeshboard("no");
            hrDeshboard.Show();
            this.Close();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = 0;
            id = insertLogIn();
            if (id > 0)
            {
                if (insertJob(id) && insertEmployee(id) && insertAddress(id))
                {
                    MessageBox.Show("Employee Add Sucessful", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private int insertLogIn()
        {
            
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            OleDbDataReader reader;
            int id = 0;
            // Check input Validation
            if (!isLoginValid())
            {
                MessageBox.Show("User & Pass Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return 0;
            }
            //Check Database User Validation
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT [ID] FROM Login WHERE [User] = @user ", conn);
                command.Parameters.AddWithValue("@user", txtUsername.Text);
                conn.Open();
                reader = command.ExecuteReader();               
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                    if (id > 0)
                    {
                        MessageBox.Show("LogIn User Name Already exits : ");
                        return 0;
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return 0;
            }
            //Check Insert Database User
            try
            {
                string query = "Insert into Login ([User],[Pass]) values (@user,@pass)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            } catch (Exception ex) {
                conn.Close();
                MessageBox.Show("LogIn failer : "+ex.Message);
            }
            //Check get id Database User 
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT [ID] FROM Login WHERE [User] = @user ", conn);
                command.Parameters.AddWithValue("@user", txtUsername.Text);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                    if (id > 0)
                    {
                        return id;
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
                return 0;
            }
            return 0;
        }

        private bool insertJob(int id)
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
                string query = "Insert into Job ([Id],[Department],[Title],[Salary],[Join_Date]) values (@id,@depart,@title,@salary,@date)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@depart", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@date", dateOfJoin.Value.ToShortDateString());
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

        private bool insertEmployee(int id)
        {
           
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isEmployeeValid())
            {
                MessageBox.Show("EMployee Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            try
            {
                string query = "Insert into Employee ([Id],[Name],[Phone],[Email],[NID],[DOB]) values (@id,@name,@phone,@email,@nid,@dob)";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@nid", txtNid.Text);
                cmd.Parameters.AddWithValue("@dob", dateDOB.Value.ToShortDateString());
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

        private bool insertAddress(int id)
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
                string query = "Insert into Address ([Id],[House],[Street],[Area],[Post],[City],[State]) values (@id,@house,@street,@area,@post,@city,@state)";
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
    }
}
