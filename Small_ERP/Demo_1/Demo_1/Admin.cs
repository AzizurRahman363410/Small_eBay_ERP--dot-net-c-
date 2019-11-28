using System;
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
    public partial class Admin : Form
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

        public Admin()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            setChart();
        }
        public void setChart()
        {
            chart1.Series["Profit"].Points.AddXY("May", 177);
            chart1.Series["Profit"].Points.AddXY("Jun", 345);
            chart1.Series["Profit"].Points.AddXY("Jul", 157);
            chart1.Series["Profit"].Points.AddXY("Ags", 414);
            chart1.Series["Profit"].Points.AddXY("Sep", 355);
            chart1.Series["Profit"].Points.AddXY("Oct", 547);
            chart1.Series["Profit"].Points.AddXY("Nov", 657);
            chart1.Series["Profit"].Points.AddXY("Dec", 274);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void profitBtn_Click(object sender, EventArgs e)
        {
            Profit profit = new Profit();
            profit.ShowDialog();
        }

        private void emailBtn_Click(object sender, EventArgs e)
        {
            Email email = new Email();
            email.ShowDialog();
        }

        private void hrBtn_Click(object sender, EventArgs e)
        {
            HrDeshboard hrDeshboard = new HrDeshboard("back");
            hrDeshboard.Show();
            this.Close();
        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            InvantoryDeshboard invantoryDeshboard = new InvantoryDeshboard("back");
            invantoryDeshboard.Show();
            this.Close();
        }

        private void salesBtn_Click(object sender, EventArgs e)
        {
            SalesDeshBoard salesDeshBoard = new SalesDeshBoard("back");
            salesDeshBoard.Show();
            this.Close();
        }
    }
}
