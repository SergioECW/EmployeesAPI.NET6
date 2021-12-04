using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Data;
using Object;
using Business;

namespace WebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Business.EmployeeController employeeController = new Business.EmployeeController();
        Employee employeeInstance = new Employee();
        List<Employee> employees = new List<Employee>();
        
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            employees = employeeController.GetEmployees();
            if(employees == null || employees.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(employees);
            }            
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            try
            {
                employeeController.CreateEmployee(employee);
                return Ok("Creado");
            }
            catch(Exception ex)
            {
                return ValidationProblem(ex.Message.ToString());
            }

        }

        [HttpPost]
        [Route("GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            employeeInstance = employeeController.GetEmployeeById(id);
            if(employeeInstance == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(employeeInstance);
            }
        }

        [HttpPut]
        [Route("EditEmployee")]
        public IActionResult EditEmployee(Employee employee)
        {
            try
            {
              employeeController.EditEmployee(employee);
                return Ok("Editado");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            

        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                employeeController.DeleteEmployee(id);
                return Ok("Eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
