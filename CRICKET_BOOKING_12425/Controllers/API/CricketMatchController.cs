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
        [Route("ListMatch/{CricketMatchesId?}")]

        public async Task<IActionResult> ListMatch(int? CricketMatchesId)
        {
            try
            {
                var Data = await _dbContext.CricketMatches.Where(o=>o.CricketMatchesId == CricketMatchesId).ToListAsync();
                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
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

        [HttpGet]
        [Route("DisplayMatch")]
        public async Task<IActionResult> DisplayMatch()
        {
            try
            {
                var Data = await (from A in _dbContext.AdminMasters
                                  join B in _dbContext.Tournaments on A.AdminMasterId equals B.AdminMasterId
                                  join C in _dbContext.CricketMatches on B.TournamentId  equals C.TournamentId
                                  select new{
                                     A.Logo,
                                     A.Address,
                                     A.CubName,
                                     A.FullName,
                                     B.TournamentName,
                                     B.Amount,
                                     C.TeamA,
                                     C.TeamB,
                                     C.Venue,
                                     C.MatchDate,
                                     C.Note,
                                     B.TournamentId,
                                  }).ToListAsync();
                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [Route("MoreMatch/{TournamentId?}")]
        public async Task<IActionResult> MoreMatch(int? TournamentId)
        {
            try
            {
                var Data = await (from A in _dbContext.AdminMasters
                                  join B in _dbContext.Tournaments on A.AdminMasterId equals B.AdminMasterId
                                  join C in _dbContext.CricketMatches on B.TournamentId equals C.TournamentId
                                  where C.TournamentId == TournamentId
                                  select new
                                  {
                                      A.Logo,
                                      A.Address,
                                      A.PhoneNo,
                                      A.CubName,
                                      A.FullName,
                                      B.TournamentName,
                                      B.Amount,
                                      C.TeamA,
                                      C.TeamB,
                                      C.Venue,
                                      C.MatchDate,
                                      C.Note,
                                      B.TournamentId,
                                  }).ToListAsync();
                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not found" });
                }
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
                                     C.CricketMatchesId,
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

        [HttpGet]
        [Route("MatchSchedule/{TournamentId?}")]

        public async Task<IActionResult> MatchSchedule(int? TournamentId)
        {
            try
            {
                var Data = await (from A in _dbContext.Tournaments
                                  join C in _dbContext.CricketMatches on A.TournamentId equals C.TournamentId
                                  where C.TournamentId == TournamentId 
                                  select new 
                                  {
                                   C.TeamA,
                                   C.TeamB,
                                   C.MatchDate,
                                   C.Venue,
                                   C.Note,
                                  }).ToListAsync();
            if (Data != null)
            {
                return Ok(new { Status = "Ok", Result = Data });
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


        [HttpGet]
        [Route("Delete/{CricketMatchesId?}")]

        public async Task<IActionResult> DeleteMatch(int? CricketMatchesId)
        {
            try
            {
                var Data = await _dbContext.CricketMatches.FirstOrDefaultAsync(o => o.CricketMatchesId == CricketMatchesId);

                if (Data != null)
                {
                    _dbContext.CricketMatches.Remove(Data);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Delete Successfully" });
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

        [HttpPost]
        [Route("UpdateMatch")]
        public async Task<IActionResult> UpdateMatch(Cricket_Matches cricket_Matches)
        {
            try
            {
                var existingMatch = await _dbContext.CricketMatches
                    .FirstOrDefaultAsync(m => m.CricketMatchesId == cricket_Matches.CricketMatchesId);

                if (existingMatch == null)
                {
                    return Ok(new { Status = "Fail", Result = "Match not found" });
                }

                // Only update specific fields
                existingMatch.TeamA = cricket_Matches.TeamA;
                existingMatch.TeamB = cricket_Matches.TeamB;
                existingMatch.MatchDate = cricket_Matches.MatchDate;
                existingMatch.Venue = cricket_Matches.Venue;
                existingMatch.Match_type = cricket_Matches.Match_type;
                existingMatch.Match_status = cricket_Matches.Match_status;
                existingMatch.ClubName = cricket_Matches.ClubName;
                existingMatch.Note = cricket_Matches.Note;

                await _dbContext.SaveChangesAsync();

                return Ok(new { Status = "Ok", Result = "Update Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

    }
}
