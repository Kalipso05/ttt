using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadsOfRussiaWeb.Entities;
using RoadsOfRussiaWeb.Models;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet(Name = "GetEmployees")]
        public List<EmployeeResponse> GetEmployees()
        {
            using (var db = new DbRoadContext())
            {
                var employeesList = db.Employees.Include(p => p.IdStructuralDivisionNavigation).Include(p => p.IdJobTitleNavigation).ToList().ConvertAll(p => new EmployeeResponse(p));
                return employeesList;
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutPatient(int id, EmployeeRequest employee)
        {
            using(var db = new DbRoadContext())
            {
                var existingEmployee = db.Employees.FirstOrDefault(e => e.Id ==  id);
                if(existingEmployee != null)
                {
                    existingEmployee.Phone = employee.Phone;
                    existingEmployee.DateOfBirth = employee.DateOfBirth;
                    db.SaveChanges();
                    return Accepted();
                }
                return NotFound();
            }
        }
    }
}
