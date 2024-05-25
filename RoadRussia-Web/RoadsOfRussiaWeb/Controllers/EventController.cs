using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadsOfRussiaWeb.Entities;
using RoadsOfRussiaWeb.Models;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public List<EventResponse> GetEvents()
        {
            using (var db = new DbRoadContext())
            {
                var eventList = db.Events.Include(p => p.IdTypeEventNavigation).Include(p => p.IdStatusEventNavigation).Include(p => p.IdEmployeeNavigation).ToList().ConvertAll(p => new EventResponse(p));

                return eventList;
            }
        }
    }
}
