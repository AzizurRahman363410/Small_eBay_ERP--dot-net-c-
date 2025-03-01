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
    public partial class Profit : Form
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

        public Profit()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
