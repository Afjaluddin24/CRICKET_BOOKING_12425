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
                var existingImg = await _dbContext.HeaderImgs.ToListAsync();
                if (existingImg != null)
                {
                    return Ok(new { Status = "Exists", Result = "Only one image is allowed." });
                }

                byte[] imageBytes = Convert.FromBase64String(HeaderImg.Imgs);

                string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "IMG");
                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                }

                string fileName = $"Img_{DateTime.Now:yyyyMMddHHmmssfff}.png";
                string filePath = Path.Combine(imageDirectory, fileName);
                await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                HeaderImg.Imgs = fileName;
                _dbContext.HeaderImgs.Add(HeaderImg);
                await _dbContext.SaveChangesAsync();

                return Ok(new { Status = "Ok", Result = "Saved Successfully" });


            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("ImgDisplay/{MaineAdminId?}")]

        public async Task<IActionResult> ImgDisplay(int? MaineAdminId)
        {
            try
            {
                var Data = await _dbContext.HeaderImgs.Where(o=>o.MaineAdminId == MaineAdminId).ToListAsync();

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

        [HttpGet]
        [Route("Detals/{HeaderImgId?}")]

        public async Task<IActionResult> Detals(int? HeaderImgId)
        {
            try
            {
                var Data = await _dbContext.HeaderImgs.Where(o => o.HeaderImgId == HeaderImgId).FirstOrDefaultAsync();

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
