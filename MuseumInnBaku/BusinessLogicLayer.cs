using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumInnBaku
{
    class BusinessLogicLayer
    {
        DataAccessLayer dal;
        public BusinessLogicLayer()
        {
            dal = new DataAccessLayer();

        }
        public int ControlLogin(string Username,string Password)
        {
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                return dal.LoginControl(new UserLogin { Username = Username, Password = Password });

            }
            return -1;
        }
        public int AddUserCustomer(string Fname, string Lname, string Username, string Password, int CardNumber, int PhoneNumber,int id)
        {
            if (!String.IsNullOrEmpty(Fname) 
                && !String.IsNullOrEmpty(Lname)
                && !String.IsNullOrEmpty(Username)
                && !String.IsNullOrEmpty(Password)
                && !String.IsNullOrEmpty(CardNumber.ToString())
                && !String.IsNullOrEmpty(PhoneNumber.ToString())
                && !String.IsNullOrEmpty(id.ToString()))
            {
                return dal.AddUserAndCustomer(new AddNewUser
                {
                    FirstName = Fname,
                    PhoneNumber = PhoneNumber,
                    CardNumber = CardNumber,
                    LastName = Lname,
                    Password = Password,
                    Username = Username,
                    ID=id
                });

            }
            return -1;
        }
        public int AddCategory(string Cname)
        {
            if (!String.IsNullOrEmpty(Cname))
            {
                return dal.AddNewCategory(new AddCategory
                {
                    CategoryName = Cname
                }); 

            }
            return -1;
        }
        public int AddEmployee(string Ename, string ELname, int Salary, string DepName)
        {
            if (!String.IsNullOrEmpty(Ename)
                && !String.IsNullOrEmpty(ELname)
                &&  !String.IsNullOrEmpty(Salary.ToString()) 
                && !String.IsNullOrEmpty(DepName) )
            {
                return dal.AddNewEmployee(new AddEmp
                {
                    EmployeeName=Ename,
                    EmployeeSurname=ELname,
                    Salary=Salary,
                    DepartmentName=DepName
                });

            }
            
            return -1;
        }
        public int AddProduct(string Pname, double Price, int Count, int CategID)
        {
            if (!String.IsNullOrEmpty(Pname)
                && !String.IsNullOrEmpty(Price.ToString()) 
                && !String.IsNullOrEmpty(Count.ToString()) 
                && !String.IsNullOrEmpty(CategID.ToString()))
            {
                return dal.AddNewProduct(new AddNewProduct
                {
                    Name=Pname,
                    Price=Price,
                    Count=Count,
                    CategID=CategID
                });

            }

            return -1;
        }
        public int DeleteProduct(int ProdID)
        {
            if (!String.IsNullOrEmpty(ProdID.ToString()))
            {
                return dal.DeleteProduct(new AddNewProduct
                {
                   ProdID=ProdID
                });

            }

            return -1;
        }
        public int DeleteCategory(int categID)
        {
            if (!String.IsNullOrEmpty(categID.ToString()))
            {
                return dal.DeleteCategory(new AddCategory
                {
                    CategoryID=categID
                });

            }

            return -1;
        }
        public int DeleteEmployee(int empID)
        {
            if (!String.IsNullOrEmpty(empID.ToString()))
            {
                return dal.DeleteEmployee(new AddEmp
                {
                    EmployeeID=empID
                });

            }

            return -1;
        }
        public int UpdateProduct(int ProdID,string Pname, double Price, int Count,string CategName)
        {
            if (!String.IsNullOrEmpty(Pname) 
                && !String.IsNullOrEmpty(Price.ToString())
                && !String.IsNullOrEmpty(Count.ToString()) 
                && !String.IsNullOrEmpty(ProdID.ToString())
                && !String.IsNullOrEmpty(CategName))
            {
                return dal.UpdateProduct(new AddNewProduct
                {
                    Name = Pname,
                    Price = Price,
                    Count = Count,
                    ProdID = ProdID
                });

            }

            return -1;
        }
        public int UpdateEmployee(string Ename, string ELname, int Salary, string DepName,int EmpID)
        {
            if (!String.IsNullOrEmpty(Ename)
                && !String.IsNullOrEmpty(ELname)
                && !String.IsNullOrEmpty(Salary.ToString())
                && !String.IsNullOrEmpty(DepName) 
                && !String.IsNullOrEmpty(EmpID.ToString()))
            {
                return dal.UpdateEmployee(new AddEmp
                {
                    EmployeeName = Ename,
                    EmployeeSurname = ELname,
                    Salary = Salary,
                    DepartmentName = DepName,
                    EmployeeID=EmpID
                });

            }

            return -1;
        }
        public int UpdateCategory(string Cname,int CategID)
        {
            if (!String.IsNullOrEmpty(Cname) && !String.IsNullOrEmpty(CategID.ToString()))
            {
                return dal.UpdateCategory(new AddCategory
                {
                    CategoryName = Cname,
                   CategoryID=CategID
                });

            }
            return -1;
        }
        public int GetByCategName(string Cname)
        {
            if (!String.IsNullOrEmpty(Cname) )
            {
                return dal.GetByCategName(new AddCategory
                {
                    CategoryName = Cname
                    
                });

            }
            return -1;
        }
        public int AddOrder(string Oname, string Address,int CustID, int countOrder)
        {
            if (!String.IsNullOrEmpty(Oname)
                && !String.IsNullOrEmpty(Address) 
                && !String.IsNullOrEmpty(CustID.ToString())
                && !String.IsNullOrEmpty(countOrder.ToString()))
            {

                return dal.AddOrder(new AddOrder
                {
                    OrderName=Oname,
                    Address=Address,
                    CustomerID=CustID,
                    CountOrder=countOrder
                });

            }
            return -1;
        }

    }
}
