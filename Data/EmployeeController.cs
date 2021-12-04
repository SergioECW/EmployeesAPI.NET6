using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object;

namespace Data
{
    public class EmployeeController
    {
        Employee employeeInstance = new Employee();
        List<Employee> employeeList = new List<Employee>();
        string cs = "Data Source=DESKTOP-NA8GVVS;Initial Catalog=Employees;Integrated Security=True";

        public List<Employee> GetEmployees()
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GET_EMPLOYEES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.employeeId = Convert.ToInt32(reader["EMPLOYEEID"]);
                    employee.companyId = (int)reader["COMPANYID"];
                    employee.createdOn = reader["CREATEDON"].ToString();
                    employee.deletedOn = reader["DELETEDON"].ToString();
                    employee.email = reader["EMAIL"].ToString();
                    employee.fax = (int)reader["FAX"];
                    employee.lastLogin = reader["LASTLOGIN"].ToString();
                    employee.name = reader["NAME"].ToString();
                    employee.password = reader["PASSWORD"].ToString();
                    employee.portalId = (int)reader["PORTALID"];
                    employee.roleId = (int)reader["ROLEID"];
                    employee.statusId = (int)reader["STATUSID"];
                    employee.telephone = (int)reader["TELEPHONE"];
                    employee.updatedOn = reader["UPDATEON"].ToString();
                    employee.username = reader["USERNAME"].ToString();

                    employeeList.Add(employee);
                }
                con.Close();
            }
            return employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GET_EMPLOYEE_BY_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@IDEMPLOYEE", id);
                SqlDataReader reader = cmd.ExecuteReader();                
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.employeeId = Convert.ToInt32(reader["EMPLOYEEID"]);
                    employee.companyId = (int)reader["COMPANYID"];
                    employee.createdOn = reader["CREATEDON"].ToString();
                    employee.deletedOn = reader["DELETEDON"].ToString();
                    employee.email = reader["EMAIL"].ToString();
                    employee.fax = (int)reader["FAX"];
                    employee.lastLogin = reader["LASTLOGIN"].ToString();
                    employee.name = reader["NAME"].ToString();
                    employee.password = reader["PASSWORD"].ToString();
                    employee.portalId = (int)reader["PORTALID"];
                    employee.roleId = (int)reader["ROLEID"];
                    employee.statusId = (int)reader["STATUSID"];
                    employee.telephone = (int)reader["TELEPHONE"];
                    employee.updatedOn = reader["UPDATEON"].ToString();
                    employee.username = reader["USERNAME"].ToString();

                    employeeInstance = employee;
                }                
            }
            return employeeInstance;
        }

        public void CreateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CREATE_EMPLOYEES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@COMPANYID", Convert.ToInt32(employee.companyId));
                cmd.Parameters.AddWithValue("@CREATEDON", employee.createdOn);
                cmd.Parameters.AddWithValue("@DELETEDON", employee.deletedOn);
                cmd.Parameters.AddWithValue("@EMAIL", employee.email);
                cmd.Parameters.AddWithValue("@FAX", employee.fax);
                cmd.Parameters.AddWithValue("@LASTLOGIN", employee.lastLogin);
                cmd.Parameters.AddWithValue("@NAME", employee.name);
                cmd.Parameters.AddWithValue("@PASSWORD", employee.password);
                cmd.Parameters.AddWithValue("@PORTALID", employee.portalId);
                cmd.Parameters.AddWithValue("@ROLEID", employee.roleId);
                cmd.Parameters.AddWithValue("@STATUSID", employee.statusId);
                cmd.Parameters.AddWithValue("@TELEPHONE", employee.telephone);
                cmd.Parameters.AddWithValue("@UPDATEON", employee.updatedOn);
                cmd.Parameters.AddWithValue("@USERNAME", employee.username);
                cmd.ExecuteNonQuery();                
            }
        }

        public void EditEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_EMPLOYEES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@COMPANYID", Convert.ToInt32(employee.companyId));
                cmd.Parameters.AddWithValue("@CREATEDON", employee.createdOn);
                cmd.Parameters.AddWithValue("@DELETEDON", employee.deletedOn);
                cmd.Parameters.AddWithValue("@EMAIL", employee.email);
                cmd.Parameters.AddWithValue("@FAX", employee.fax);
                cmd.Parameters.AddWithValue("@LASTLOGIN", employee.lastLogin);
                cmd.Parameters.AddWithValue("@NAME", employee.name);
                cmd.Parameters.AddWithValue("@PASSWORD", employee.password);
                cmd.Parameters.AddWithValue("@PORTALID", employee.portalId);
                cmd.Parameters.AddWithValue("@ROLEID", employee.roleId);
                cmd.Parameters.AddWithValue("@STATUSID", employee.statusId);
                cmd.Parameters.AddWithValue("@TELEPHONE", employee.telephone);
                cmd.Parameters.AddWithValue("@UPDATEON", employee.updatedOn);
                cmd.Parameters.AddWithValue("@USERNAME", employee.username);
                cmd.ExecuteNonQuery();                
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE_EMPLOYEES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@IDEMPLOYEE", id);
                cmd.ExecuteNonQuery();               
            }
        }
    }
}
