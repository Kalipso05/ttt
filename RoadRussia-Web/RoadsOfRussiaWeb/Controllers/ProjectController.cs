using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadsOfRussiaWeb.Entities;
using RoadsOfRussiaWeb.Models;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public List<InformationProjectResponse> GetInformationProjects()
        {
            using (var db = new DbRoadContext())
            {
                var data = db.InformationProjects.Include(p => p.IdDirectorProjectNavigation).Include(p => p.IdDevelopmentStageNavigation).ToList().ConvertAll(p => new InformationProjectResponse(p));
                return data;
            }
        }
    }
}
