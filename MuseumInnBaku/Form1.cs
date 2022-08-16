using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuseumInnBaku
{
    public partial class Form1 : Form
    {
        SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("server=LAPTOP-P5II427C; database=DB_MuseumInnBakuApp; trusted_connection=true");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnl_login.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            pnl_system_login.BringToFront();

        }

        private void btn_customerlogin_Click(object sender, EventArgs e)
        {

            pnl_customer_login.BringToFront();


        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserSignUpForm userSignUpForm = new UserSignUpForm();
            userSignUpForm.Show();

        }

        private void pnl_system_login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_login_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btn_systementer_Click(object sender, EventArgs e)
        {
            if (txt_systemUsername.Text == "booleanteach" && txt_systemPassword.Text == "bool123")
            {
                SystemGirish systemGirish = new SystemGirish();
                this.Hide();
                systemGirish.Show();

            }
            else if (txt_systemUsername.Text == "booleanteach" && txt_systemPassword.Text != "bool123")
            {
                MessageBox.Show("Please,enter password correctly!");
                txt_systemPassword.Clear();
            }
            else
            {
                MessageBox.Show("Please,enter correctly!");
                txt_systemPassword.Clear();
                txt_systemUsername.Clear();
            }
        }
       private void btn_customerenter_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer bll = new BusinessLogicLayer();
            var control = bll.ControlLogin(txt_customerUsername.Text, txt_customerPassword.Text);
            if (control>0)
            {
                UserEnteredForm userEnteredForm = new UserEnteredForm();
                userEnteredForm.CustName= txt_customerUsername.Text;
                userEnteredForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please,enter correctly");
                txt_customerPassword.Clear();
            }
        }

        private void txt_systemUsername_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txt_systemUsername_Enter(object sender, EventArgs e)
        {
            if (txt_systemUsername.Text == "Username")
            {
                txt_systemUsername.Text = "";
                txt_systemUsername.ForeColor = Color.Black;

            }
        }

        private void txt_systemUsername_Leave(object sender, EventArgs e)
        {
            if (txt_systemUsername.Text == "")
            {
                txt_systemUsername.Text = "Username";
                txt_systemUsername.ForeColor = Color.Silver;

            }
        }

        private void txt_systemPassword_Leave(object sender, EventArgs e)
        {
            if (txt_systemPassword.Text == "")
            {
                txt_systemPassword.Text = "******";
                txt_systemPassword.ForeColor = Color.Silver;

            }
        }

        private void txt_systemPassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_customerUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_customerUsername_Enter(object sender, EventArgs e)
        {
            if (txt_customerUsername.Text == "Username")
            {
                txt_customerUsername.Text = "";
                txt_customerUsername.ForeColor = Color.Black;

            }
        }

        private void txt_systemPassword_Enter(object sender, EventArgs e)
        {
            if (txt_systemPassword.Text == "******")
            {
                txt_systemPassword.Text = "";
                txt_systemPassword.ForeColor = Color.Black;

            }
        }

        private void txt_customerUsername_Leave(object sender, EventArgs e)
        {
            if (txt_customerUsername.Text == "")
            {
                txt_customerUsername.Text = "Username";
                txt_customerUsername.ForeColor = Color.Silver;

            }
        }

        private void txt_customerPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_customerPassword_Leave(object sender, EventArgs e)
        {
            if (txt_customerPassword.Text == "")
            {
                txt_customerPassword.Text = "********";
                txt_customerPassword.ForeColor = Color.Silver;

            }
        }

        private void txt_customerPassword_Enter(object sender, EventArgs e)
        {
            if (txt_customerPassword.Text == "********")
            {
                txt_customerPassword.Text = "";
                txt_customerPassword.ForeColor = Color.Black;

            }
        }

        private void cb_PassHide_CheckedChanged(object sender, EventArgs e)
        {
       



        }

        private void cb_PassHide_CheckStateChanged(object sender, EventArgs e)
        {
            if (cb_PassHide.Checked)
            {
                txt_customerPassword.PasswordChar = '\0';
            }
            else
            {
                txt_customerPassword.PasswordChar = '*';
            }
       
        }
    }
}
