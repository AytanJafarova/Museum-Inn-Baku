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
    public partial class SystemGirish : Form
    {
        SqlConnection connection;
        BusinessLogicLayer bll;

        public SystemGirish()
        {
            InitializeComponent();
            connection = new SqlConnection("server=LAPTOP-P5II427C; database=DB_MuseumInnBakuApp; trusted_connection=true");
            bll = new BusinessLogicLayer();
        }
        public void GetAll()
        {
            tbl_CategoryTableAdapter1.Fill(dB_MuseumInnBakuAppDataSet1.Tbl_Category);
            tbl_EmployeeTableAdapter.Fill(dB_MuseumInnBakuAppDataSet2.Tbl_Employee);
            tbl_ProductTableAdapter1.Fill(dB_MuseumInnBakuAppDataSet15.Tbl_Product);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_empl_oper.Show();
            linepanel2.Height = btn_emp_operation.Height;
            linepanel2.Top = btn_emp_operation.Top;

            pnl_ctgry_oper.Hide();
            pnl_prdct_oper.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnl_empl_oper.Hide();
            pnl_ctgry_oper.Hide();
            pnl_prdct_oper.Show();
            linepanel2.Height = btn_prod_operation.Height;
            linepanel2.Top = btn_prod_operation.Top;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnl_empl_oper.Hide();
            pnl_prdct_oper.Hide();
            pnl_ctgry_oper.Show();
            linepanel2.Height = btn_categ_operation.Height;
            linepanel2.Top = btn_categ_operation.Top;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();

        }

        private void pnl_ctgry_oper_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SystemGirish_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet15.Tbl_Product' table. You can move, or remove it, as needed.
            this.tbl_ProductTableAdapter1.Fill(this.dB_MuseumInnBakuAppDataSet15.Tbl_Product);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet12.Tbl_Category' table. You can move, or remove it, as needed.
            this.tbl_CategoryTableAdapter3.Fill(this.dB_MuseumInnBakuAppDataSet12.Tbl_Category);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet5.Tbl_Product' table. You can move, or remove it, as needed.
            this.tbl_ProductTableAdapter.Fill(this.dB_MuseumInnBakuAppDataSet5.Tbl_Product);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet2.Tbl_Employee' table. You can move, or remove it, as needed.
            this.tbl_EmployeeTableAdapter.Fill(this.dB_MuseumInnBakuAppDataSet2.Tbl_Employee);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuAppDataSet1.Tbl_Category' table. You can move, or remove it, as needed.
            this.tbl_CategoryTableAdapter1.Fill(this.dB_MuseumInnBakuAppDataSet1.Tbl_Category);
            // TODO: This line of code loads data into the 'dB_MuseumInnBakuDataSet.Tbl_Category' table. You can move, or remove it, as needed.
     
            style_dgw_categ();
            style_dgw_emp();
            style_dgw_prod();
            cmb_categfromProd.Text = "";
            cmb_department.Text = "";

        }

        private void dgw_categ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void style_dgw_categ()
        {
            dgw_categ.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgw_categ.DefaultCellStyle.SelectionBackColor = Color.Chocolate;
        }
        void style_dgw_emp()
        {
            dgw_emp_op.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgw_emp_op.DefaultCellStyle.SelectionBackColor = Color.Chocolate;
        }
        void style_dgw_prod()
        {
            dgw_prod.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgw_prod.DefaultCellStyle.SelectionBackColor = Color.Chocolate;
        }

        private void btn_add_categ_Click(object sender, EventArgs e)
        {
            try { 
            connection.Open();

            int result = bll.AddCategory(txt_categNameop.Text);
            if (result > 0)
            {
                MessageBox.Show("Added successfully!");
                txt_categNameop.Clear();
                txt_categIDop.Clear();

                GetAll();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Try again!");
                txt_categNameop.Clear();
                txt_categIDop.Clear();

                connection.Close();
            }

               }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            }
        public void GetData()
        {
            DataTable dataTable = new DataTable();

            DataTable dataTable1 = new DataTable();

            string GetByCategQuery = $"select ProductID,ProductName,ProductPrice,ProductCount,(select CategoryID from Tbl_Category where CategoryName= '{cmb_categfromProd.Text}') as CategoryID from Tbl_Product p1 inner join Tbl_Category p2 on p1.CategoryID = p2.CategoryID where CategoryName = '{cmb_categfromProd.Text}'";

            string GetProd = $"select EmployeeID,EmployeeName,EmployeeSurname,EmployeeSalary,EmployeeDepartment from Tbl_Employee where EmployeeDepartment='{cmb_department.Text}'";

            SqlDataAdapter adapter = new SqlDataAdapter(GetByCategQuery, connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(GetProd, connection);
            connection.Close();

            adapter.Fill(dataTable);
            adapter1.Fill(dataTable1);

            dgw_prod.DataSource = dataTable;
            dgw_emp_op.DataSource = dataTable1;
        }

        private void btn_add_emp_Click(object sender, EventArgs e)
        {
            try { 
            connection.Open();
            string depname = cmb_department.Text;
            int empSalary = Convert.ToInt32(txt_empSalaryop.Text);

            int result = bll.AddEmployee(txt_empNameop.Text,txt_empSurnameop.Text,empSalary,depname);
            if (result > 0)
            {
                MessageBox.Show("Added successfully!");
                txt_empNameop.Clear();
                txt_empSalaryop.Clear();
                txt_empSurnameop.Clear();
                txt_empIDop.Clear();
                cmb_department.Text = "";


                GetAll();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Try again!");
                txt_empNameop.Clear();
                txt_empSalaryop.Clear();
                txt_empSurnameop.Clear();
                txt_empIDop.Clear();
                cmb_department.Text = "";
                connection.Close();
            }
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void btn_add_prod_Click(object sender, EventArgs e)
        {
            try { 
            connection.Open();
            SqlCommand cmd2 = new SqlCommand("GetCategID", connection);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@CategName", cmb_categfromProd.Text);
            int idOF = Convert.ToInt32(cmd2.ExecuteScalar());

           double priceP = Convert.ToDouble(txt_ProdPriceop.Text);
            int countP = Convert.ToInt32(txt_ProdCountop.Text);


            int result = bll.AddProduct(txt_ProdNameop.Text, priceP, countP, idOF);
            if (result > 0)
            {
                MessageBox.Show("Added successfully!");
                txt_ProdNameop.Clear();
                txt_ProdPriceop.Clear();
                txt_ProdCountop.Clear();
                cmb_categfromProd.Text = "";


                GetAll();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Try again!");
                txt_ProdNameop.Clear();
                txt_ProdPriceop.Clear();
                txt_ProdCountop.Clear();
                cmb_categfromProd.Text = "";
                connection.Close();
            }
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void btn_delete_prod_Click(object sender, EventArgs e)
        {
            try { 
            connection.Open();

            int delId = Convert.ToInt32(txt_ProductIDop.Text);
            int result = bll.DeleteProduct(delId);
            if (result > 0)
            {
                MessageBox.Show("Deleted successfully!");
                txt_ProdNameop.Clear();
                txt_ProdPriceop.Clear();
                txt_ProdCountop.Clear();
                txt_ProductIDop.Clear();
                cmb_categfromProd.Text = "";

               
                GetAll();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Try again!");
                txt_ProdNameop.Clear();
                txt_ProdPriceop.Clear();
                txt_ProdCountop.Clear();
                txt_ProductIDop.Clear();
                cmb_categfromProd.Text = "";
                connection.Close();

            }
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void dgw_prod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            connection.Open();
            int index = dgw_prod.SelectedCells[0].RowIndex;
            txt_ProductIDop.Text = dgw_prod.Rows[index].Cells[0].Value.ToString();
            txt_ProdNameop.Text = dgw_prod.Rows[index].Cells[1].Value.ToString();
            txt_ProdPriceop.Text = dgw_prod.Rows[index].Cells[2].Value.ToString();
            txt_ProdCountop.Text = dgw_prod.Rows[index].Cells[3].Value.ToString();
            SqlCommand cmd2 = new SqlCommand("spGetCategName", connection);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@CategID", dgw_prod.Rows[index].Cells[4].Value);
            string nameOf = Convert.ToString(cmd2.ExecuteScalar());

            cmb_categfromProd.Text=nameOf;
            connection.Close();
        }

        private void dgw_emp_op_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            connection.Open();
            int index = dgw_emp_op.SelectedCells[0].RowIndex;
            txt_empIDop.Text=dgw_emp_op.Rows[index].Cells[0].Value.ToString();
            txt_empNameop.Text = dgw_emp_op.Rows[index].Cells[1].Value.ToString();
            txt_empSurnameop.Text = dgw_emp_op.Rows[index].Cells[2].Value.ToString();
            txt_empSalaryop.Text = dgw_emp_op.Rows[index].Cells[3].Value.ToString();
            cmb_department.Text = dgw_emp_op.Rows[index].Cells[4].Value.ToString();
           
            connection.Close();
        }

        private void dgw_categ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            connection.Open();
            int index = dgw_categ.SelectedCells[0].RowIndex;
            txt_categIDop.Text = dgw_categ.Rows[index].Cells[0].Value.ToString();
            txt_categNameop.Text = dgw_categ.Rows[index].Cells[1].Value.ToString();
 

            connection.Close();
        }

        private void btn_delete_categ_Click(object sender, EventArgs e)
        {
            try { 
            connection.Open();

            int delId = Convert.ToInt32(txt_categIDop.Text);
            int result = bll.DeleteCategory(delId);
            if (result > 0)
            {
                MessageBox.Show("Deleted successfully!");
                txt_categIDop.Clear();
                txt_categNameop.Clear();


                GetAll();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Try again!");
                txt_categIDop.Clear();
                txt_categNameop.Clear();
                connection.Close();

            }
        }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void btn_delete_emp_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

            int delId = Convert.ToInt32(txt_empIDop.Text);
            int result = bll.DeleteEmployee(delId);
            if (result > 0)
            {
                MessageBox.Show("Deleted successfully!");
                txt_empNameop.Clear();
                txt_empSalaryop.Clear();
                txt_empSurnameop.Clear();
                txt_empIDop.Clear();
                cmb_department.Text = "";

                GetAll();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Try again!");
                txt_empNameop.Clear();
                txt_empSalaryop.Clear();
                txt_empSurnameop.Clear();
                txt_empIDop.Clear();
                cmb_department.Text = "";
                connection.Close();

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_prod_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                double priceP = Convert.ToDouble(txt_ProdPriceop.Text);
                int countP = Convert.ToInt32(txt_ProdCountop.Text);
                int prodID = Convert.ToInt32(txt_ProductIDop.Text);


                int result = bll.UpdateProduct(prodID, txt_ProdNameop.Text, priceP, countP,cmb_categfromProd.Text);
                if (result > 0)
                {
                    MessageBox.Show("Updated successfully!");
                    txt_ProdNameop.Clear();
                    txt_ProdPriceop.Clear();
                    txt_ProdCountop.Clear();
                    txt_ProductIDop.Clear();
                    cmb_categfromProd.Text = "";


                    GetAll();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Try again!");
                    txt_ProdNameop.Clear();
                    txt_ProdPriceop.Clear();
                    txt_ProdCountop.Clear();
                    txt_ProductIDop.Clear();
                    cmb_categfromProd.Text = "";

                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_emp_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string depname = cmb_department.Text;
                int empSalary = Convert.ToInt32(txt_empSalaryop.Text);
                int empID = Convert.ToInt32(txt_empIDop.Text);

                int result = bll.UpdateEmployee(txt_empNameop.Text, txt_empSurnameop.Text, empSalary, depname, empID);
                if (result > 0)
                {
                    MessageBox.Show("Updated successfully!");
                    txt_empNameop.Clear();
                    txt_empSalaryop.Clear();
                    txt_empSurnameop.Clear();
                    txt_empIDop.Clear();
                    cmb_department.Text = "";


                    GetAll();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Try again!");
                    txt_empNameop.Clear();
                    txt_empSalaryop.Clear();
                    txt_empSurnameop.Clear();
                    txt_empIDop.Clear();
                    cmb_department.Text = "";
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          
        }

        private void btn_update_categ_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                int ID = Convert.ToInt32(txt_categIDop.Text);

                int result = bll.UpdateCategory(txt_categNameop.Text, ID);
                if (result > 0)
                {
                    MessageBox.Show("Updated successfully!");
                    txt_categNameop.Clear();
                    txt_categIDop.Clear();

                    GetAll();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Try again!");
                    txt_categNameop.Clear();
                    txt_categIDop.Clear();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cmb_categfromProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
