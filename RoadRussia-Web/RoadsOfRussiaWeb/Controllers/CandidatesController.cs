using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadsOfRussiaWeb.Entities;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        [HttpGet]
        public List<Candidate> GetCandidates()
        {
            using (var db = new DbRoadContext())
            {
                var candidatesList = db.Candidates.ToList();
                return candidatesList;
            }
        }
    }
}
