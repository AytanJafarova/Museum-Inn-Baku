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
    public partial class UserSignUpForm : Form
    {
        SqlConnection connection;
        BusinessLogicLayer bll;
        public UserSignUpForm()
        {
            InitializeComponent();
            connection = new SqlConnection("server=LAPTOP-P5II427C; database=DB_MuseumInnBakuApp; trusted_connection=true");
            bll = new BusinessLogicLayer();
        }

        private void UserSignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_SignUpCust_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd= new SqlCommand("select max(CustomerID) from Tbl_Customer", connection);

            var IDnumber = Convert.ToInt32(cmd.ExecuteScalar());

            int result = bll.AddUserCustomer(
                txt_custNameN.Text, 
                txt_custSurnameN.Text, 
                txt_custUsernameN.Text,
                txt_custPasswordN.Text, 
                Convert.ToInt32(txt_custCardN.Text), 
                Convert.ToInt32(txt_custPhoneN.Text),
                IDnumber);
            if (result > 0)
            {
                MessageBox.Show("Added successfully!\nNow sign in please!");
                txt_custCardN.Clear();
                txt_custNameN.Clear();
                txt_custPasswordN.Clear();
                txt_custPhoneN.Clear();
                txt_custSurnameN.Clear();
                txt_custUsernameN.Clear();
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Try again!");

            }
            connection.Close();
        }
        private void btn_resetNewUser_Click(object sender, EventArgs e)
        {
            txt_custCardN.Clear();
            txt_custNameN.Clear();
            txt_custPasswordN.Clear();
            txt_custPhoneN.Clear();
            txt_custSurnameN.Clear();
            txt_custUsernameN.Clear();
        }
    }
}
