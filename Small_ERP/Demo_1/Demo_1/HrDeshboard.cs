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
    public partial class HrDeshboard : Form
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

        public HrDeshboard(string adminBack)
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            setChart();
            back = adminBack;
        }

        public void setChart()
        {
            chart1.Series["Employee"].Points.AddXY("May", 177);
            chart1.Series["Employee"].Points.AddXY("Jun", 345);
            chart1.Series["Employee"].Points.AddXY("Jul", 157);
            chart1.Series["Employee"].Points.AddXY("Ags", 414);
            chart1.Series["Employee"].Points.AddXY("Sep", 355);
            chart1.Series["Employee"].Points.AddXY("Oct", 547);
            chart1.Series["Employee"].Points.AddXY("Nov", 657);
            chart1.Series["Employee"].Points.AddXY("Dec", 274);
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

        private void emailBtn_Click(object sender, EventArgs e)
        {
            Email email = new Email();
            email.ShowDialog();
        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
            this.Close();
        }

        private void employeListBtn_Click(object sender, EventArgs e)
        {
            EmployeeList employeeList = new EmployeeList();
            employeeList.Show();
            this.Close();
        }

        private void updateEmployeeBtn_Click(object sender, EventArgs e)
        {
            UpdateEmployee updateEmployee = new UpdateEmployee();
            updateEmployee.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
