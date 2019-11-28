﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1
{
    public partial class SalesDeshBoard : Form
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

        private string back;

        public SalesDeshBoard(string adminBack)
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            setChart();
            back = adminBack;
        }
        public void setChart()
        {
            chart1.Series["Product"].Points.AddXY("May", 177);
            chart1.Series["Product"].Points.AddXY("Jun", 345);
            chart1.Series["Product"].Points.AddXY("Jul", 157);
            chart1.Series["Product"].Points.AddXY("Ags", 414);
            chart1.Series["Product"].Points.AddXY("Sep", 355);
            chart1.Series["Product"].Points.AddXY("Oct", 547);
            chart1.Series["Product"].Points.AddXY("Nov", 657);
            chart1.Series["Product"].Points.AddXY("Dec", 274);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (back.Equals("back"))
            {
                Admin admin = new Admin();
                admin.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addSalsBtn_Click(object sender, EventArgs e)
        {
            AddSales sales = new AddSales();
            sales.Show();
            this.Close();

        }

        private void salesListBtn_Click(object sender, EventArgs e)
        {
            SalesList salesList = new SalesList();
            salesList.Show();
            this.Close();

        }

        private void updateSalesBtn_Click(object sender, EventArgs e)
        {
            UpdateSales updateSales = new UpdateSales();
            updateSales.Show();
            this.Close();
        }
    }
}