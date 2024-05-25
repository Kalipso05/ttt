using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoadsOfRussiaWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisioController : ControllerBase
    {
        private readonly string _uploadsDirectory;

        public VisioController()
        {
            _uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            // Создаем папку для загрузок, если она не существует
            if (!Directory.Exists(_uploadsDirectory))
            {
                Directory.CreateDirectory(_uploadsDirectory);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadVisio([FromForm] VisioUploadModel model)
        {
            try
            {
                if (model == null || model.File == null || model.File.Length == 0)
                    return BadRequest("No file uploaded.");

                string fileName = $"{Guid.NewGuid().ToString()}.vsdx";
                string filePath = Path.Combine(_uploadsDirectory, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                return Ok($"File uploaded successfully: {fileName}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading file: {ex.Message}");
            }
        }
    }

    public class VisioUploadModel
    {
        public IFormFile File { get; set; }
    }
}
