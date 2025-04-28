using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public BookingController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("BookingTeams")]

        public async Task<IActionResult> BookingTeams(BookingTeams bookingTeams)
        {
            try
            {
                // Convert base64 string to byte array for logo
                byte[] imageBytes = Convert.FromBase64String(bookingTeams.Logo);

                // Define the directory to store the logo
                var logoDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logo");

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
                bookingTeams.Logo = fileName;

                // Add the booking team to the database
                _dbContext.BookingsTeams.Add(bookingTeams);
                await _dbContext.SaveChangesAsync();

                return Ok(new { Status = "Ok", Result = "Booking Successfully" });
            }
            catch (DbUpdateException dbEx)
            {
                // Handle database-specific errors
                return Ok(new { Status = "Fail", Result = "Database update failed", InnerException = dbEx.InnerException?.Message });
            }
            catch (Exception ex)
            {
                // Log the general exception
                return Ok(new { Status = "Fail", Result = ex.Message, InnerException = ex.InnerException?.Message });
            }
        }


        [HttpGet]
        [Route("BookingList/{AdminMasterId?}")]
        public async Task<IActionResult> BookingList(int? AdminMasterId)
        {
            try
            {
                var data = await (from C in _dbContext.BookingsTeams 
                                  join D in _dbContext.Tournaments on C.TournamentId equals D.TournamentId
                                  where D.AdminMasterId == AdminMasterId
                                  select new
                                  {
                                      C.BookingDate,
                                      C.TeamsName,
                                      C.ContactNo,
                                      C.CricHeroesUrl,
                                      C.CaptainName,
                                      C.Email,
                                      C.VCaptainName,
                                      C.Logo,
                                      C.VContactNo,
                                      C.BookingTeamsId,
                                      D.TournamentName,
                                      D.Amount,
                                  }).ToListAsync();

                if (data.Any())
                {
                    return Ok(new { Status = "Ok", Result = data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "No records found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Error", Result = ex.Message });
            }

        }

        [HttpGet]
        [Route("TournamentTeams/{TournamentId}")]

        public async Task<IActionResult> TournamentTeams(int? TournamentId)
        {
            try
            {
                var Data = await _dbContext.BookingsTeams.Where(o=> o.TournamentId == TournamentId).ToListAsync();
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
        [Route("BookingDelete/{TournamentId?}")]
        public async Task<IActionResult> BookingDelete(int? TournamentId)
        {
            try
            {
                var data = await _dbContext.BookingsTeams.FindAsync(TournamentId);

                if (data != null)
                {
                    _dbContext.BookingsTeams.Remove(data);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Delete Successfully" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Try Agen" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Error", Result = ex.Message });
            }

        }

    }
}
