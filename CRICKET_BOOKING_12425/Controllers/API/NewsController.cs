using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public NewsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddNews")]
        public async Task<IActionResult> AddNews(New News)
        {
            try
            {
                // Convert base64 string to byte array for logo
                byte[] imageBytes = Convert.FromBase64String(News.Imgs);

                // Define the directory to store the logo
                var logoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "IMG");

                // Create directory if it doesn't exist
                if (!Directory.Exists(logoDirectory))
                {
                    Directory.CreateDirectory(logoDirectory);
                }

                // Generate a unique file name for the logo
                string fileName = "Img" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                var filePath = Path.Combine(logoDirectory, fileName);

                // Save the image to disk
                System.IO.File.WriteAllBytes(filePath, imageBytes);

                // Update the logo file name in the bookingTeams object
                News.Imgs = fileName;

                _dbContext.News.Add(News);
                await _dbContext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Save Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }

        }

        [HttpGet]
        [Route("NewDisplay/{AdminMasterId?}")]

        public async Task<IActionResult> NewDisplay(int? AdminMasterId)
        {
            try
            {
                var Data = await _dbContext.News.FindAsync(AdminMasterId);

                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("NewList")]

        public async Task<IActionResult> NewList()
        {
            try
            {
                var Data = await _dbContext.News.ToListAsync();

                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }
    }
}
