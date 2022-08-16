using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumInnBaku
{
    class DataAccessLayer
    {
        SqlConnection connection;
        public DataAccessLayer()
        {
            connection = new SqlConnection("server=LAPTOP-P5II427C; database=DB_MuseumInnBakuApp; trusted_connection=true");
        }
      
        public int LoginControl(UserLogin login)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spLoginControl", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", login.Username);
                cmd.Parameters.AddWithValue("@Password", login.Password);
               
                connection.Open();
                var count = cmd.ExecuteScalar();
                connection.Close();
                return (int)count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int AddUserAndCustomer(AddNewUser newUser)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddNewUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", newUser.FirstName);
                cmd.Parameters.AddWithValue("@surname", newUser.LastName);
                cmd.Parameters.AddWithValue("@cardNumber", newUser.CardNumber);
                cmd.Parameters.AddWithValue("@phoneNumber", newUser.PhoneNumber);
                cmd.Parameters.AddWithValue("@username", newUser.Username);
                cmd.Parameters.AddWithValue("@password", newUser.Password);
                cmd.Parameters.AddWithValue("@key", newUser.ID);
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int AddNewCategory(AddCategory category)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddCategroy", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
               
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int AddNewEmployee(AddEmp emp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Surname", emp.EmployeeSurname);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@DepartmentName", emp.DepartmentName);

                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int AddNewProduct(AddNewProduct product)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Count", product.Count);
                cmd.Parameters.AddWithValue("@CategID", product.CategID);

                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int DeleteProduct(AddNewProduct product)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProdID", product.ProdID);
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int DeleteCategory(AddCategory category)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteCategory", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categID", category.CategoryID);
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int DeleteEmployee(AddEmp emp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empID", emp.EmployeeID);
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int UpdateProduct(AddNewProduct product)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prodName", product.Name);
                cmd.Parameters.AddWithValue("@prodPrice", product.Price);
                cmd.Parameters.AddWithValue("@prodCount", product.Count);
                cmd.Parameters.AddWithValue("@prodId", product.ProdID);


                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int UpdateEmployee(AddEmp emp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmp", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Surname", emp.EmployeeSurname);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@DepartmentName", emp.DepartmentName);
                cmd.Parameters.AddWithValue("@EmpID", emp.EmployeeID);


                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int UpdateCategory(AddCategory category)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateCateg", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategName", category.CategoryName);
                cmd.Parameters.AddWithValue("@CategID", category.CategoryID);
                connection.Open();
                int count = cmd.ExecuteNonQuery();
                connection.Close();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        public int GetByCategName(AddCategory category)
        {
            SqlCommand cmd = new SqlCommand("spGetByCategName", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categName", category.CategoryName);
            connection.Open();
            int count = cmd.ExecuteNonQuery();
            connection.Close();
            return count;
        }
        public int AddOrder(AddOrder order)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddOrder", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderName",order.OrderName);
                cmd.Parameters.AddWithValue("@address", order.Address);
                cmd.Parameters.AddWithValue("@getCustId", order.CustomerID);

                connection.Open();
                int count1 = cmd.ExecuteNonQuery();
                connection.Close();

                SqlCommand cmd1 = new SqlCommand("spChangeProductInfo", connection);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@orderName", order.OrderName);
                cmd1.Parameters.AddWithValue("@countOrder", order.CountOrder);

                connection.Open();
                int count2 = cmd1.ExecuteNonQuery();
                connection.Close();

                if (count1>0 && count2>0)
                {
                    return count1+count2;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }
}
