using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadsOfRussiaWeb.Entities;
using RoadsOfRussiaWeb.Models;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        private readonly IWebHostEnvironment _appEnvironment;
        public LibraryController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public List<DocumentSection> GetDocumentSections()
        {
            using (var db = new DbRoadContext())
            {

                var typeList = db.DocumentSections.ToList();
                return typeList;
            }
        }

        //[HttpGet]
        //public IActionResult GetFile()
        //{
        //    string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.vsdx");
        //    string file_type = "application/vnd.visio";
        //    string file_name = "book.vsdx";
        //    return PhysicalFile(file_path, file_type, file_name);
        //}



        [HttpGet("{id}")]
        public List<LibraryResponse> GetTypeLibraries(int id)
        {
            using (var db = new DbRoadContext())
            {
                var typeList = db.Libraries.Include(p => p.IdDocumentSectionNavigation).Where(i => i.IdDocumentSection == id).ToList().ConvertAll(p => new LibraryResponse(p));
                return typeList;
            }

            
        }


    }
}
