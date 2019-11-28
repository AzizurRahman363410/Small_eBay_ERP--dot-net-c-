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
    public partial class LogIn : Form
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
        public LogIn()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usernameTb_MouseClick(object sender, MouseEventArgs e)
        {
            usernameTb.Text = "";
        }

        private void passwordTb_MouseClick(object sender, MouseEventArgs e)
        {
            passwordTb.Text = "";
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username;
            string password;

            username = usernameTb.Text;
            password = passwordTb.Text;
            if (username.Equals("admin") && password.Equals("admin"))
            {
                Admin admin = new Admin();
                admin.Show();
                this.WindowState = FormWindowState.Minimized;
            }
            else if (username.Equals("hr123") && password.Equals("hr123"))
            {
                username.StartsWith("");
            }
            else if (username.Equals("inv123") && password.Equals("inv123"))
            {
               
            }
            else if (username.Equals("sal123") && password.Equals("sal123"))
            {
               
            }
            else
            {
                MessageBox.Show("Username & Password Invalid");
                usernameTb.Text = "Username";
                passwordTb.Text = "Password";
            }
        }

        private void forgetPassBtn_Click(object sender, EventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.ShowDialog();
        }
    }
}
