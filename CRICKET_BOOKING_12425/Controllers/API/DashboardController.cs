using CRICKET_BOOKING_12425.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public DashboardController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("DisplayDashboard/{AdminMasterId?}")]

        public async Task<IActionResult> DisplayDashboard(int? AdminMasterId)
        {
            try
            {
                var admin = await _dbContext.AdminMasters.FindAsync(AdminMasterId);

                if (admin != null)
                {
                    var Tournament = await _dbContext.Tournaments.CountAsync();
                    var Teams = await _dbContext.BookingsTeams.CountAsync();
                    var Match = await _dbContext.CricketMatches.CountAsync();

                    return Ok(new { Status = "Ok", Result = new { Tournament, Teams, Match } });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Admin not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = "Fail", Result = ex.Message });
            }
        }


    }
}
