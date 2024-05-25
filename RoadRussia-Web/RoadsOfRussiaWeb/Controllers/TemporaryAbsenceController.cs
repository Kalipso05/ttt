using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadsOfRussiaWeb.Entities;
using RoadsOfRussiaWeb.Models;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryAbsenceController : ControllerBase
    {
        [HttpGet("{id}")]
        public AbsenceResponse GetAbsences(int id)
        {
            using (var db = new DbRoadContext())
            {
                var absences = db.TemporaryAbsenceEmployees.Where(p => p.IdEmployee == id).Include(p => p.IdEmployeeNavigation).ToList().ConvertAll(p => new AbsenceResponse(p)).FirstOrDefault();
                return absences;
            }
        }
    }
}
