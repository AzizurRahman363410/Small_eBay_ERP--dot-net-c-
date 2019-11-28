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
    public partial class ProductListcs : Form
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
        public ProductListcs()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            load();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void load()
        {

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Product", conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Product");
            dataGridView1.DataSource = ds.Tables["Product"];
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(ConnectionString);

            string query1 = "Delete From Product Where [Id]=@id";
            OleDbCommand cmd1 = new OleDbCommand(query1, conn);
            cmd1.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            load();
        }

        private void backHrBut_Click(object sender, EventArgs e)
        {
            InvantoryDeshboard invantory = new InvantoryDeshboard("no");
            invantory.Show();
            this.Close();
        }
    }
}
