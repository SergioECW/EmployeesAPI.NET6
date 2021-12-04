using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object;
using Data;
using System.Data;

namespace Business
{
    public class EmployeeController
    {
        Employee employeeInstance = new Employee();
        List<Employee> employeeList = new List<Employee>();
        Data.EmployeeController DataEmployeeController = new Data.EmployeeController();
        public List<Employee> GetEmployees()
        {
            employeeList = DataEmployeeController.GetEmployees();
            return employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            employeeInstance = DataEmployeeController.GetEmployeeById(id);
            return employeeInstance;
        }
        
        public void CreateEmployee(Employee employee)
        {
            employee.createdOn = DateTime.Now.ToString();
            DataEmployeeController.CreateEmployee(employee);
        }

        public void EditEmployee(Employee employee)
        {
            employee.updatedOn = DateTime.Now.ToString();
            DataEmployeeController.EditEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            //employee.deletedOn = DateTime.Now.ToString();
            DataEmployeeController.DeleteEmployee(id);
        }
    }
}
