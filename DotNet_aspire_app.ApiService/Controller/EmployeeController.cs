using DotNet_aspire_app.ApiService.model;
using DotNet_aspire_app.ApiService.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet_aspire_app.ApiService.Controller
{
    [Route("api/emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly EmployeeService _empService;

        public EmployeeController(EmployeeService empService)
        {

            _empService = empService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> GetEmployee()
        {
            var empData = await _empService.GetAllemployee();
            return Ok(empData);
        }

        [HttpPost("Add")]
          public async Task<ActionResult> AddEmployee(EmployeeModel employee)
        {

            var Employees = new EmployeeModel()
            {
                FullName = employee.FullName,
                Position = employee.Position,
                Salary = employee.Salary,
            };

            if (employee == null)
            {
                return BadRequest("Employee Cannot be null");
            }

            var AddEmp = await _empService.AddEmployee(Employees);

             return Ok(AddEmp);

            //return CreatedAtAction(nameof(GetEmployee), new { id = AddEmp.Id }, AddEmp);
        }

        [HttpDelete("Delete/{id}")]
         
        public async Task<ActionResult> DeleteEmployee (int id)
        {
             var res = await _empService.DeleteEmp(id);

            if (res)
            {
                return Ok(new { Message = "Employee deleted successfully." });
            }
            else
            {
                return NotFound(new { Message = "Employee not found." });
            }
        }
        [HttpPut("Update/{id}")]
          public async Task<ActionResult> UpdateEmployee(int id, EmployeeModel employee)
        {
            var Id = await _empService.UpdateEmployeeId(id ,employee);

            if(Id == null)
            {
                return NotFound(new { Message = "Employee not found." });
            }
            else
            {
                return Ok(new { Message = "Employee Update successfully." });
                
            }
           

        }

      /*  private readonly AspireDBcontext _context; // Add context as a private field

        // Inject the context through the constructor
        public EmployeeController(AspireDBcontext context)
        {
            _context = context;
        }*/
        /*   
          private readonly EmployeeService _employeeService;

          public EmployeeController(EmployeeService employeeService)
          {
              _employeeService = employeeService;
          }

  */
        /* [HttpGet]
         public ActionResult<List<EmployeeModel>> GetEmployee()
         {
             var Employees = _employeeService.GetAllemployee();

             return Ok(Employees);
         }*/
      /*  [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> GetEmployees() // Change method signature to async
        {
            var employees = await _context.Employees.ToListAsync(); // Fetch data directly from the context

            return Ok(employees); // Return the list of employees
        }*/
    }
}
