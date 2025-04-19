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
                // Get the booking limit entry by BookingLimetId
                var bookingLimit = await _dbContext.BookingsLimets
                    .Where(x => x.BookingLimetId == bookingTeams.BookingLimetId)
                    .FirstOrDefaultAsync();

                // Count existing bookings for this BookingLimetId
                var existingBookings = await _dbContext.BookingsTeams
                    .Where(o => o.BookingLimetId == bookingTeams.BookingLimetId)
                    .ToListAsync();

                // If the number of existing bookings is >= BookingPerson, booking is full
                if (bookingLimit != null && existingBookings.Count >= bookingLimit.BookingPerson)
                {
                    return Ok(new { Status = "Fail", Result = "Booking Full" });
                }

                // Check for duplicate values
                List<string> errors = new List<string>();

                if (existingBookings.Any(o => o.TeamsName == bookingTeams.TeamsName))
                {
                    errors.Add("Team name already exists.");
                }
                if (existingBookings.Any(o => o.ContactNo == bookingTeams.ContactNo))
                {
                    errors.Add("Contact number already exists.");
                }
                if (existingBookings.Any(o => o.CricHeroesUrl == bookingTeams.CricHeroesUrl))
                {
                    errors.Add("CricHeroes URL already exists.");
                }
                if (existingBookings.Any(o => o.Email == bookingTeams.Email))
                {
                    errors.Add("Email already exists.");
                }

                if (errors.Count > 0)
                {
                    return Ok(new { Status = "Fail", Result = errors });
                }

                if (string.IsNullOrEmpty(bookingTeams.Logo))
                {
                    return Ok(new { Status = "Fail", Result = "Logo is required." });
                }

                try
                {
                    byte[] imageBytes = Convert.FromBase64String(bookingTeams.Logo);

                    // Ensure the directory exists
                    var tournamentImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logo");
                    if (!Directory.Exists(tournamentImg))
                    {
                        Directory.CreateDirectory(tournamentImg);
                    }

                    // Generate file name with a 24-hour format
                    string fileName = "Img" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

                    // Create the full file path
                    var filePath = Path.Combine(tournamentImg, fileName);

                    // Save the image to the server
                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    // Update the tournament logo field with the saved file name
                    bookingTeams.Logo = fileName;
                }
                catch (FormatException)
                {
                    return Ok(new { Status = "Fail", Result = "Invalid logo format." });
                }

                // Save the booking data
                _dbContext.BookingsTeams.Add(bookingTeams);
                await _dbContext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Booking Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
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
