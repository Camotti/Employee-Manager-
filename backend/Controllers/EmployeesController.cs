using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Data;

namespace backend.Controllers;


[ApiController]
[Route("api/[Controller]")]

public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee= await _context.Employees.FindAsync(id);
        if(employee == null)
        {
            return NotFound();
        }

        return employee; 
    }


    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);   
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetEmployee),
            new {id= employee.id}, employee);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id )
    {
        var employee= await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
         _context.Employees.Remove(employee);
         await _context.SaveChangesAsync();
         return NoContent();
    }

  [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
    {
        if (id != employee.id)
        {
            return BadRequest();
        }

        var existingEmployee = await _context.Employees.FindAsync(id);

        if (existingEmployee == null)
        {
            return NotFound();
        }

        existingEmployee.name = employee.name;
        existingEmployee.department = employee.department;
        existingEmployee.salary = employee.salary;

        await _context.SaveChangesAsync();

        return NoContent();
    }
}



