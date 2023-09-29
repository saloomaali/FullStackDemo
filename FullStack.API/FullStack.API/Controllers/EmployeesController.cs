using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly FullStackDbContext _fullStackDbContext;

        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullStackDbContext.VbEmployees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequested)
        {
            employeeRequested.Id = Guid.NewGuid();
            await _fullStackDbContext.VbEmployees.AddAsync(employeeRequested);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(employeeRequested);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackDbContext.VbEmployees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updatedEmployeeRequest)
        {
            var employee = await _fullStackDbContext.VbEmployees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            employee.Name = updatedEmployeeRequest.Name;
            employee.Email = updatedEmployeeRequest.Email; 
            employee.Phone = updatedEmployeeRequest.Phone;
            employee.Salary = updatedEmployeeRequest.Salary;
            employee.Department = updatedEmployeeRequest.Department;

            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackDbContext.VbEmployees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _fullStackDbContext.VbEmployees.Remove(employee);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(employee);
         }
    }
}
