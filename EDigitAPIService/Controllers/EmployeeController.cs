using EDigitAPIService.DAL;
using EDigitAPIService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDigitAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeDAL _employeeDAL;

        public EmployeeController(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeDAL.GetAllEmployees());
        }

        [HttpPost]

        public IActionResult AddEmpoyee([FromBody] Employee employee)
        {
            var msg = _employeeDAL.AddEmployee(employee);

            var result = new StatusMessage
            {
                Message = msg
            };

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            return Ok(_employeeDAL.GetEmployeeById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee([FromRoute] int id, Employee employee)
        {
            return Ok(_employeeDAL.UpdateEmployee(id, employee));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            return Ok(_employeeDAL.DeleteEmployee(id));
        }
    }

    public  class StatusMessage
    {
        public string Message { get; set; }
    }
}
