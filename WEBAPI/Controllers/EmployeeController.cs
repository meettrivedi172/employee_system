using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPI.Data;
using WEBAPI.Dtos;
using WEBAPI.Entity;

namespace WEBAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController  : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext  context)
         {
            _context = context;
        }




    [HttpPost("add-employee")]
    public async Task<ActionResult<AppUser>> AddEmployee(AppUser employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return Ok(employee);
    }


     [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, AppUser employee)
    {
        var existingEmployee = await _context.Employees.FindAsync(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }

        existingEmployee.Email = employee.Email;
        existingEmployee.Name = employee.Name;
        existingEmployee.Dob = employee.Dob;
        existingEmployee.Department = employee.Department;
         existingEmployee.Gender = employee.Gender;

        _context.Employees.Update(existingEmployee);
        await _context.SaveChangesAsync();

        return NoContent();
    }




       [HttpGet("{identifier}")]
    public async Task<IActionResult> GetEmployeeByIdOrName(string identifier)
    {
        int id;
        bool isId = int.TryParse(identifier, out id);

     var employee = await _context.Employees.Where(e => isId ? e.Id == id : e.Name == identifier || e.Department == identifier).ToListAsync();

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }







        [HttpGet]
    public async Task<IActionResult> GetEmployees(string gender, string department)
    {
        var employees = await _context.Employees.ToListAsync();

        if (!string.IsNullOrWhiteSpace(gender))
        {
            employees = employees.Where(e => e.Gender.ToLower() == gender.ToLower()).ToList();
        }

        if (!string.IsNullOrWhiteSpace(department))
        {
            employees = employees.Where(e => e.Department.ToLower() == department.ToLower()).ToList();
        }

    
        return Ok(employees);
    }



    }
}