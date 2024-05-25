using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadsOfRussiaWeb.Entities;
using RoadsOfRussiaWeb.Models;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        [HttpGet]
        public List<JobTitleResponse> GetJobTitles()
        {
            using (var db = new DbRoadContext())
            {
                var jobTitleList = db.JobTitles.Include(p => p.IdStructuralDivisionNavigation).ToList().ConvertAll(p => new JobTitleResponse(p));
                return jobTitleList;
            }
        }

    }
}
