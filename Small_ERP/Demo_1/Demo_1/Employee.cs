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
    public partial class Employee : Form
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
        public Employee(int id)
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            load(id);

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
                    labUsername.Text = ": " + reader["User"].ToString();
                    labPassword.Text = ": " + reader["Pass"].ToString();
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
                    labDepartment.Text = ": " + reader["Department"].ToString();
                    labTitle.Text = ": " + reader["Title"].ToString();
                    labSalary.Text = ": " + reader["Salary"].ToString();
                    labDate.Text = ": " + reader["Join_Date"].ToString();

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
                    labId.Text = ": " + reader["ID"].ToString();
                    labName.Text = ": " + reader["Name"].ToString();
                    labPhone.Text = ": " + reader["Phone"].ToString();
                    labEmail.Text = ": " + reader["Email"].ToString();
                    labNid.Text = ": " + reader["NID"].ToString();
                    labDOB.Text = ": " + reader["DOB"].ToString();
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
                    labHouse.Text = ": " + reader["House"].ToString();
                    labStreet.Text = ": " + reader["Street"].ToString();
                    labArea.Text = ": " + reader["Area"].ToString();
                    labPost.Text = ": " + reader["Post"].ToString();
                    labCity.Text = ": " + reader["City"].ToString();
                    labState.Text = ": " + reader["State"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("LogIn failer : " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
