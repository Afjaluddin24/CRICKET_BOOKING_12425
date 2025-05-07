using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderNevicationController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public HeaderNevicationController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddImages")]

        public async Task<IActionResult> AddNews(HeaderImg HeaderImg)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(HeaderImg.Imgs);

                string logoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "IMG");

                if (!Directory.Exists(logoDirectory))
                {
                    Directory.CreateDirectory(logoDirectory);
                }

                string fileName = $"Img{DateTime.Now:yyyyMMddHHmmss}.png";
                string filePath = Path.Combine(logoDirectory, fileName);

                await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                HeaderImg.Imgs = fileName;

                _dbContext.HeaderImgs.Add(HeaderImg);
                await _dbContext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Save Successfully" });

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("ImgDisplay")]

        public async Task<IActionResult> ImgDisplay()
        {
            try
            {
                var Data = await _dbContext.HeaderImgs.ToListAsync();

                if(Data != null)
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
