using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadsOfRussiaWeb.Entities;
using RoadsOfRussiaWeb.Models;

namespace RoadsOfRussiaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost("PostSingleFile")]
        public async Task<IActionResult> PostSingleFile([FromForm] FileUploadModel file)
        {
            if (file == null)
            {
                return BadRequest();
            }
            try
            {
                var fileDetails = new FilesDetail()
                {
                    FileName = file.FileDetails.FileName,
                    FileType = file.FileType,
                };
                using(var stream = new MemoryStream())
                {
                    file.FileDetails.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }
                using (var db = new DbRoadContext())
                {
                    var result = db.FilesDetails.Add(fileDetails);
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("DownloadFile")]
        public async Task<FileContentResult> DonwloadFile(int id)
        {
            try
            {
                using(var db = new DbRoadContext())
                {
                    var file = db.FilesDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
                    var content = new System.IO.MemoryStream(file.Result.FileData);
                    if (file.Result.FileType == FileType.PDF)
                    {
                        return File(file.Result.FileData, "application/pdf", file.Result.FileName);
                    }
                    else
                    {
                        return File(file.Result.FileData, "application/docx", file.Result.FileName);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
