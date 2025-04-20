using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketMatchController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;

        public CricketMatchController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("PlayMatch")]

        public async Task<IActionResult> PlayMatch(Cricket_Matches cricket_Matches)
        {
            try
            {
                _dbContext.CricketMatches.Add(cricket_Matches);
                await _dbContext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Areng Match Successsully" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("TounamentMatchDisplay/{TournamentId?}")]

        public async Task<IActionResult> TounamentMatchDisplay(int? TournamentId)
        {
            try
            {
                var Data = await (from A in _dbContext.Tournaments
                                  join B in _dbContext.CricketMatches on A.TournamentId equals B.TournamentId
                                  where B.TournamentId == TournamentId
                                  select new
                                  {
                                      A.TournamentId,
                                      A.TournamentName,
                                      A.TournamentType,
                                      B.TeamA,
                                      B.TeamB,
                                      B.MatchDate,
                                      B.Venue,
                                      B.Note,
                                      B.CricketMatchesId
                                  }).ToListAsync();
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
        [Route("PalyMatchDisplay/{AdminMasterId?}")]

        public async Task<IActionResult> PalyMatchDisplay(int? AdminMasterId)
        {
            try
            {
                var Data = await(from A in _dbContext.AdminMasters
                                 join B in _dbContext.BookingsTeams on A.AdminMasterId equals B.AdminMasterId
                                 join C in _dbContext.CricketMatches on B.BookingTeamsId equals C.BookingTeamsId
                                 where C.AdminMasterId == AdminMasterId 
                                 select new
                                 {
                                     B.Logo,
                                     B.CricHeroesUrl,
                                     B.CaptainName,
                                     B.ContactNo,
                                     C.TeamA,
                                     C.TeamB,
                                     C.MatchDate,
                                     C.Venue,
                                     C.Note,
                                 }).ToListAsync();
                if(Data != null)
                {
                    return Ok(new {Status ="Ok" , Result =Data});
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not founde" });
                }
                
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }
    }
}
