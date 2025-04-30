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
        public async Task<IActionResult> AddNews(New news)
        {
            try
            {
                // Convert base64 string to byte array
                byte[] imageBytes = Convert.FromBase64String(news.Imgs);

                // Define the directory to save the image
                string logoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "IMG");

                // Ensure the directory exists
                if (!Directory.Exists(logoDirectory))
                {
                    Directory.CreateDirectory(logoDirectory);
                }

                // Generate a unique filename
                string fileName = $"Img{DateTime.Now:yyyyMMddHHmmss}.png";
                string filePath = Path.Combine(logoDirectory, fileName);

                // Write the file to disk
                await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                // Update the news image path to filename only
                news.Imgs = fileName;

                // Save to database
                _dbContext.News.Add(news);
                await _dbContext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Save Successfully" });

            }
            catch (Exception ex)
            {
                // Handle any errors and return the error message
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }



        [HttpGet]
        [Route("NewDisplay/{AdminMasterId?}")]

        public async Task<IActionResult> NewDisplay(int? AdminMasterId)
        {
            try
            {
                var Data = await (from A in _dbContext.News
                                  join B in _dbContext.News on A.AdminMasterId equals B.AdminMasterId
                                  where B.AdminMasterId == AdminMasterId
                                  select new
                                  {
                                     A.AdminMasterId,
                                     B.NewsId,
                                     B.Name,
                                     B.Imgs,
                                     B.Title,
                                     B.Date,
                                     B.Category,
                                     B.Description,
                                     B.Sore,
                                     B.TournamentId,
                                  }).ToListAsync();

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
        [HttpGet]
        [Route("Delete/{NewsId?}")]

        public async Task<IActionResult> Delete(int? NewsId)
        {
            try
            {
                var Data = _dbContext.News.Find(NewsId);

                if (Data != null)
                {
                    _dbContext.News.Remove(Data);
                    await _dbContext.SaveChangesAsync();
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
