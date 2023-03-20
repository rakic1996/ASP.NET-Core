using Microsoft.AspNetCore.Mvc;
using Projekat.Core.Services.Abstraction;
using Projekat.Core.Domain.Entities;
using Projekat.Core.Contract;

namespace Projekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var result = _employeeService.GetEmployee(id);
            Console.WriteLine(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var result = _employeeService.GetAllEmployees();
            Console.WriteLine(result);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult InsertEmployee([FromBody] EmployeeDtoInsert employee)
        {
            Employee createdEmployee = _employeeService.InsertEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok("Updated done");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            _employeeService.DeleteEmployee(Id);
            return Ok("Data Deleted");
        }
    }
}