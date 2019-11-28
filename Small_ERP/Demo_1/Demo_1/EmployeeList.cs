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
    public partial class EmployeeList : Form
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
        string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb;";
        public EmployeeList()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            load();
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
        private void load()
        {
            
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Employee", conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Employee");
            dataGridView1.DataSource = ds.Tables["Employee"];
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString);

            string query1 = "Delete From Login Where [Id]=@id";
            OleDbCommand cmd1 = new OleDbCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            string query2 = "Delete From Job Where [Id]=@id";
            OleDbCommand cmd2 = new OleDbCommand(query2, conn);
            cmd2.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            string query3 = "Delete From Employee Where [Id]=@id";
            OleDbCommand cmd3 = new OleDbCommand(query3, conn);
            cmd3.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();

            string query4 = "Delete From Address Where [Id]=@id";
            OleDbCommand cmd4 = new OleDbCommand(query4, conn);
            cmd4.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();

            load();

            MessageBox.Show("Employee Delete Sucessful", "Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Employee employee = new Employee(id);
            employee.ShowDialog();
        }
    }
}
