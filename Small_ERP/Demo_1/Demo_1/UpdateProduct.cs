﻿using System;
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
    public partial class UpdateProduct : Form
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
        public UpdateProduct()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            cmbAddItem();
        }
        private void load()
        {

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            OleDbDataReader reader;
            int id = 0;
            
            try
            {
               id = Convert.ToInt32(txtId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            //get login Data
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM Product WHERE [ID] = @id", conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtProductName.Text = reader["ProductName"].ToString();
                    txtCost.Text = reader["Cost"].ToString();
                    txtSales.Text = reader["Sales"].ToString();
                    txtStockUnit.Text = reader["Stock_Unit"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Product failer : " + ex.Message);
            }
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
            if (txtSales.Text.Trim().Equals(""))
            {
                return false;
            }
            if (txtStockUnit.Text.Trim().Equals(""))
            {
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backAdminBut_Click(object sender, EventArgs e)
        {
            InvantoryDeshboard invantory = new InvantoryDeshboard("no");
            invantory.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateEmployee();
        }
        private bool updateEmployee()
        {

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            // Check input Validation
            if (!isProductValid())
            {
                MessageBox.Show("Employee Field is required", "Invalid Input", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            int id = 0;
            try
            {
                id = Convert.ToInt32(txtId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string query = "Update Product Set [Category]= @category,[ProductName]=@productName,[Cost]=@cost,[Sales]=@sales,[Stock_Unit]=@stock_Unit,[Add_Date]=@date where [Id]=@id";
                OleDbCommand cmd = new OleDbCommand(query, conn);
      
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@productName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@cost", txtCost.Text);
                cmd.Parameters.AddWithValue("@sales", txtSales.Text);
                cmd.Parameters.AddWithValue("@stock_Unit", txtStockUnit.Text);
                cmd.Parameters.AddWithValue("@date", dateProduct.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@id", txtId.Text);
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

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbCategory.SelectedIndex;
            category = cmbCategory.Items[index].ToString();
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
    }
}