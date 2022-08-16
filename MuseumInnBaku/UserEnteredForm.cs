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
    public partial class UserEnteredForm : Form
    {
        SqlConnection connection;
        BusinessLogicLayer bll;
        public UserEnteredForm()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            connection = new SqlConnection("server=LAPTOP-P5II427C; database=DB_MuseumInnBakuApp; trusted_connection=true");
            bll = new BusinessLogicLayer();
            connection.Open();
            SqlCommand cmd8 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID", connection);
            int total = Convert.ToInt32(cmd8.ExecuteScalar());

            SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 1", connection);
            int c1 = Convert.ToInt32(cmd.ExecuteScalar());

            SqlCommand cmd1 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 2", connection);
            int c2 = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 3", connection);
            int c3 = Convert.ToInt32(cmd2.ExecuteScalar());

            SqlCommand cmd3 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 4", connection);
            int c4 = Convert.ToInt32(cmd3.ExecuteScalar());

            SqlCommand cmd4 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 5", connection);
            int c5 = Convert.ToInt32(cmd4.ExecuteScalar());

            SqlCommand cmd5 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 6", connection);
            int c6 = Convert.ToInt32(cmd5.ExecuteScalar());

            SqlCommand cmd6 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 7", connection);
            int c7 = Convert.ToInt32(cmd6.ExecuteScalar());

            SqlCommand cmd7 = new SqlCommand("select count(*) from Tbl_Order p1 inner join Tbl_Product p2 on p1.ProductID = p2.ProductID where CategoryID = 8", connection);
            int c8 = Convert.ToInt32(cmd7.ExecuteScalar());

           

            chart1.Titles.Add("Category rating:");
            chart1.Series["Categories"].IsValueShownAsLabel = true;
            chart1.Series["Categories"].Points.AddXY("Pizzas", $"{c1}");
            chart1.Series["Categories"].Points.AddXY("Hot Meals", $"{c2}");
            chart1.Series["Categories"].Points.AddXY("Salads", $"{c3}");
            chart1.Series["Categories"].Points.AddXY("Soups", $"{c4}");
            chart1.Series["Categories"].Points.AddXY("Cool Drinks", $"{c5}");
            chart1.Series["Categories"].Points.AddXY("Hot Drinks", $"{c6}");
            chart1.Series["Categories"].Points.AddXY("Plov", $"{c7}");
            chart1.Series["Categories"].Points.AddXY("Desserts", $"{c8}");

            connection.Close();

        }
        public string CustName { get; set; }
        public string CnameEntered { get; set; }
        private void btn_go_back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();

            linepanel.Height = btn_go_back.Height;
            linepanel.Top = btn_go_back.Top;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_contact_us_Click(object sender, EventArgs e)
        {
            pnl_about_us.Hide();
            pnl_MyOrdersPanel.Hide();
            pnl_Order.Hide();
            pnl_rate.Hide();
            pnl_contact_us.Show();
            linepanel.Height = btn_contact_us.Height;
            linepanel.Top = btn_contact_us.Top;
            StringBuilder builder = new StringBuilder();
            builder.Append("https://www.google.com/maps/place/Museum+Inn/@40.366553,49.8364711,15z/data=!4m8!3m7!1s0x0:0xa302acba513beb86!5m2!4m1!1i2!8m2!3d40.366553!4d49.8364711");
            webBrowser1.Navigate(builder.ToString());
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            pnl_about_us.Hide();
            pnl_contact_us.Hide();
            pnl_MyOrdersPanel.Hide();
            pnl_rate.Hide();
            pnl_Order.Show();
            linepanel.Height = btn_order.Height;
            linepanel.Top = btn_order.Top;

        }

        private void btn_my_orders_Click(object sender, EventArgs e)
        {
            connection.Open();
            DataTable dataTable = new DataTable();
            string custName2 = CustName;
            SqlCommand cmd = new SqlCommand($"select CustomerID from Tbl_User where Username='{custName2}'", connection);
            int id2 = Convert.ToInt32(cmd.ExecuteScalar());

            string GetForID = $"select OrderName,Address,OrderDate from Tbl_Order where CustomerID={id2}";
            SqlDataAdapter adapter = new SqlDataAdapter(GetForID, connection);

            adapter.Fill(dataTable);
            dgw_order_history.DataSource = dataTable;
            pnl_about_us.Hide();
            pnl_contact_us.Hide();
            pnl_Order.Hide();
            pnl_rate.Hide();
            pnl_MyOrdersPanel.Show();

            linepanel.Height = btn_my_orders.Height;
            linepanel.Top = btn_my_orders.Top;
          
            string custName = CustName;
            SqlCommand cmd1 = new SqlCommand($"select CustomerID from Tbl_User where Username='{custName}'", connection);
            int id = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand($"select CustomerName from Tbl_Customer where CustomerID='{id}'", connection);
            string enteredName = Convert.ToString(cmd2.ExecuteScalar());

            lbl_upd.Text ="Dear "+enteredName+" !";
            connection.Close();
        }

        private void btn_about_us_Click(object sender, EventArgs e)
        {
            pnl_contact_us.Hide();
            pnl_Order.Hide();
            pnl_MyOrdersPanel.Hide();
            pnl_rate.Hide();
            pnl_about_us.Show();
            linepanel.Height = btn_about_us.Height;
            linepanel.Top = btn_about_us.Top;
        }

        private void cmb_category_choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                GetAll();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }
        public void GetAll()
        {
            DataTable dataTable = new DataTable();

            DataTable dataTable1 = new DataTable();

            string GetByCategQuery = $"select ProductName,ProductPrice,ProductCount from Tbl_Product p1 inner join Tbl_Category p2 on p1.CategoryID = p2.CategoryID where CategoryName = '{cmb_category_choose.Text}' and ProductCount>0";
            
            string GetProd = $"select ProductName from Tbl_Product p1 inner join Tbl_Category p2 on p1.CategoryID = p2.CategoryID where CategoryName = '{cmb_category_choose.Text}' and ProductCount>0";
           
            SqlDataAdapter adapter = new SqlDataAdapter(GetByCategQuery, connection);
           
            SqlDataAdapter adapter1 = new SqlDataAdapter(GetProd, connection);
            connection.Close();

            adapter.Fill(dataTable);
            adapter1.Fill(dataTable1);

            dgw_menu.DataSource = dataTable;
            cmb_product_choose.DataSource = dataTable1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            linepanel.Height = button1.Height;
            linepanel.Top = button1.Top;
            pnl_contact_us.Hide();
            pnl_Order.Hide();
            pnl_MyOrdersPanel.Hide();
            pnl_about_us.Hide();
            pnl_rate.Show();
        }

        private void UserEnteredForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet11.Tbl_Order' table. You can move, or remove it, as needed.
            this.tbl_OrderTableAdapter1.Fill(this.dB_MuseumInnBakuAppDataSet11.Tbl_Order);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet10.Tbl_Order' table. You can move, or remove it, as needed.
            this.tbl_OrderTableAdapter.Fill(this.dB_MuseumInnBakuAppDataSet10.Tbl_Order);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet9.Tbl_Product' table. You can move, or remove it, as needed.
            this.tbl_ProductTableAdapter1.Fill(this.dB_MuseumInnBakuAppDataSet9.Tbl_Product);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet8.Tbl_Category' table. You can move, or remove it, as needed.
            this.tbl_CategoryTableAdapter1.Fill(this.dB_MuseumInnBakuAppDataSet8.Tbl_Category);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet7.Tbl_Category' table. You can move, or remove it, as needed.
            this.tbl_CategoryTableAdapter.Fill(this.dB_MuseumInnBakuAppDataSet7.Tbl_Category);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet6.Tbl_Product' table. You can move, or remove it, as needed.
            this.tbl_ProductTableAdapter.Fill(this.dB_MuseumInnBakuAppDataSet6.Tbl_Product);
            style_dgw_menu();
            style_dgw_orderHistory();
            cmb_category_choose.Text = "";
            cmb_product_choose.Text = "";
           
        }
        void style_dgw_menu()
        {
            dgw_menu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgw_menu.DefaultCellStyle.SelectionBackColor = Color.Chocolate;
        }

        private void btn_resetall_Click(object sender, EventArgs e)
        {
            txt_CountProd.Clear();
            txt_address.Clear();
            cmb_category_choose.Text = "";
            cmb_product_choose.Text = "";
            txt_cost.Clear();
            connection.Close();
        }
        void style_dgw_orderHistory()
        {
            dgw_order_history.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
           dgw_order_history.DefaultCellStyle.SelectionBackColor = Color.Chocolate;
        }
        private void dgw_menu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int index = dgw_menu.SelectedCells[0].RowIndex;
            cmb_product_choose.Text = dgw_menu.Rows[index].Cells[0].Value.ToString();
            connection.Open();
            SqlCommand cmd2 = new SqlCommand($"select  CategoryName  from Tbl_Product p1 inner join Tbl_Category p2 on p1.CategoryID = p2.CategoryID where ProductName = '{cmb_product_choose.Text}'", connection);
            string categName = Convert.ToString(cmd2.ExecuteScalar());
            cmb_category_choose.Text = categName;
            txt_cost.Text = dgw_menu.Rows[index].Cells[1].Value.ToString();

            connection.Close();
        }

        private void btn_GetMenu_Click(object sender, EventArgs e)
        {


        }
  
        public double Total { get; set; }
        public double Count { get; set; }

        private void btn_orderproduct_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                
                string custName = CustName;
                string prodName = cmb_product_choose.Text;
                string address = txt_address.Text;

                SqlCommand cmd2 = new SqlCommand($"select ProductPrice from Tbl_Product where ProductName='{prodName}'", connection);
                double price = Convert.ToDouble(cmd2.ExecuteScalar());

                SqlCommand cmd1 = new SqlCommand($"select CustomerID from Tbl_User where Username='{custName}'", connection);
                int id = Convert.ToInt32(cmd1.ExecuteScalar());

                SqlCommand cmd = new SqlCommand($"select ProductCount from Tbl_Product where ProductName='{prodName}'", connection);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                
                int enteredcount = Convert.ToInt32(txt_CountProd.Text);
                Count=enteredcount;
                double cash = enteredcount * price;

                Total += cash;

                if (enteredcount <= count)
                {
                    int result = bll.AddOrder(prodName, address, id, enteredcount);
                    if (result > 0)
                    {
                        MessageBox.Show("Ordered Succesfully!");
                        GetAll();
                        connection.Close();
                        enteredcount = 1;
                        txt_address.Clear();
                        cmb_category_choose.Text = "";
                        cmb_product_choose.Text = "";
                        txt_CountProd.Clear();
                        txt_cost.Clear();
                     
                    }
                    else
                    {
                        MessageBox.Show("Try again!");
                        connection.Close();
                        txt_address.Clear();
                        cmb_category_choose.Text = "";
                        cmb_product_choose.Text = "";
                        txt_CountProd.Clear();
                        txt_cost.Clear();
                     
                    }
                }
                else
                {
                    MessageBox.Show("We do not have so many products!\nTry again please!");
                    connection.Close();
                    txt_CountProd.Clear();
                   
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+ex.StackTrace);
                }
        }

        private void btn_finishordering_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Your order finished!\nTotal payment is: {Total} azn");
            connection.Close();
            Total = 0;
            txt_CountProd.Clear();
            txt_address.Clear();
            txt_cost.Clear();
        
        }

        private void pnl_MyOrdersPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_product_choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            string prodName = cmb_product_choose.Text;
            SqlCommand cmd2 = new SqlCommand($"select ProductPrice from Tbl_Product where ProductName='{prodName}'", connection);
            double price = Convert.ToDouble(cmd2.ExecuteScalar());
            connection.Close();
            txt_cost.Text = price.ToString();
          
        }

        private void txt_CountProd_TextChanged(object sender, EventArgs e)
        {
            connection.Open();
            string prodName = cmb_product_choose.Text;

            SqlCommand cmd2 = new SqlCommand($"select ProductPrice from Tbl_Product where ProductName='{prodName}'", connection);
            double price = Convert.ToDouble(cmd2.ExecuteScalar());

            SqlCommand cmd = new SqlCommand($"select ProductCount from Tbl_Product where ProductName='{prodName}'", connection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            int enteredcount;
            try
            {
                 enteredcount= Convert.ToInt32(txt_CountProd.Text);
            }
            catch (Exception)
            {

                enteredcount = 1;
            }

           

            double cash = enteredcount * price;
            txt_cost.Text = cash.ToString();
         
        }

        private void dgw_menu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnl_contact_us_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

