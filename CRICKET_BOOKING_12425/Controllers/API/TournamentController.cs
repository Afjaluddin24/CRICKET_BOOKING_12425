using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public TournamentController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddTournament")]
        public async Task<IActionResult> AddTournament(Tournament tournament)
        {
            try
            {
                var ExistTournament = await _dbContext.Tournaments.ToListAsync();
                List<string> error = new List<string>();

                if (ExistTournament.Any(o => o.TournamentName == tournament.TournamentName))
                {
                    error.Add("Tournament name already exists.");
                }

                if (error.Count == 0)
                {
                    // Handle logo file if it's provided
                    if (tournament.Logo != null)
                    {
                        try
                        {
                            byte[] imageBytes = Convert.FromBase64String(tournament.Logo);

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
                            tournament.Logo = fileName;
                        }
                        catch (Exception ex)
                        {
                            return Ok(new { Status = "Fail", Result = $"Error processing logo: {ex.Message}" });
                        }
                    }

                    // Add the tournament to the database and save
                    _dbContext.Tournaments.Add(tournament);
                    await _dbContext.SaveChangesAsync();

                    return Ok(new { Status = "Ok", Result = "Save Successfully" });
                }
                else
                {
                    // Return error if validation fails
                    return Ok(new { Status = "Fail", Result = error });
                }

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetTournament")]
        public async Task<IActionResult> GetTournament()
        {
            try
            {
                var Data = await _dbContext.Tournaments.ToListAsync();

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
        [Route("ListTournament/{TournamentId?}")]
        public async Task<IActionResult> ListTournament(int? TournamentId)
        {
            try
            {
                var Data = await _dbContext.Tournaments.Where(o=>o.TournamentId == TournamentId).FirstOrDefaultAsync();

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
        [Route("DetalsTournament/{AdminMasterId?}")]
        public async Task<IActionResult> DetalsTournament(int? AdminMasterId)
        {
            try
            {
                var Data = await (from A in _dbContext.BookingsLimets 
                                  join B in _dbContext.Tournaments on A.BookingLimetId equals B.BookingLimetId
                                  join C in _dbContext.BookingsTeams on B.TournamentId equals C.TournamentId
                                  where C.AdminMasterId == AdminMasterId
                                  select new {
                                      A.BookingPerson,
                                      B.TournamentName,
                                      B.TournamentType,
                                      A.AdminMasterId,
                                      B.Amount,
                                      C.TournamentId,
                                      C.TeamsName,
                                      C.CaptainName,
                                      C.ContactNo,
                                      C.Email,
                                      C.BookingTeamsId,
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
        [Route("Tournament/{AdminMasterId?}")]
        public async Task<IActionResult> Tournament(int? AdminMasterId)
        {
            try
            {
                var Data = await (from A in _dbContext .AdminMasters
                                  join B in _dbContext.BookingsLimets on A.AdminMasterId equals B.AdminMasterId
                                  join C in _dbContext.Tournaments
                                  on B.BookingLimetId equals C.BookingLimetId
                                  where B.AdminMasterId == AdminMasterId
                                  select new
                                  {
                                      A.CubName,
                                      B.BookingLimetId,
                                      B.BookingPerson,
                                      C.TournamentId,
                                      C.TournamentName,
                                      C.StarDate,
                                      C.Description,
                                      C.Amount,
                                      C.Logo,
                                      C.TournamentType,
                                      C.Status
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
        [Route("TournamentBookin/{TournamentId?}")]
        public async Task<IActionResult> TournamentBookin(int? TournamentId)
        {
            try
            {
                var Data = await (from A in _dbContext.AdminMasters
                                  join B in _dbContext.BookingsLimets on A.AdminMasterId equals B.AdminMasterId
                                  join C in _dbContext.Tournaments
                                  on B.BookingLimetId equals C.BookingLimetId
                                  where C.TournamentId == TournamentId
                                  select new
                                  {
                                      A.CubName,
                                      B.BookingLimetId,
                                      B.BookingPerson,
                                      B.AdminMasterId,
                                      C.TournamentId,
                                      C.TournamentName,
                                      C.StarDate,
                                      C.Description,
                                      C.Amount,
                                      C.Logo,
                                      C.TournamentType,
                                      C.Status
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
        [Route("PlayMatch/{AdminMasterId}")]

        public async Task<IActionResult> PlayMatch(int? AdminMasterId)
        {
            try
            {
                var Data = await (from A in _dbContext.BookingsLimets
                                  join B in _dbContext.Tournaments on A.BookingLimetId equals B.BookingLimetId
                                  join C in _dbContext.BookingsTeams on B.TournamentId equals C.TournamentId
                                  where C.AdminMasterId == AdminMasterId
                                  select new
                                  {
                                      B.AdminMasterId,
                                      B.TournamentId,
                                      B.TournamentName,
                                      B.TournamentType,
                                      B.BookingLimetId,
                                      A.BookingPerson,
                                      C.TeamsName,
                                      C.BookingTeamsId,
                                      C.CaptainName,
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
        [Route("DeleteTournament/{TournamentId?}")]
        public async Task<IActionResult> DeleteTournament(int? TournamentId)
        {
            try
            {
                var Data = _dbContext.Tournaments.Find(TournamentId);

                if (Data != null)
                {
                    _dbContext.Tournaments.Remove(Data);
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
        [Route("UpdateTournament")]
        public async Task<IActionResult> UpdateTournament(Tournament tournament)
        {
            try
            {
                    if (tournament.Logo != null)
                    {
                        byte[] imageBytes = Convert.FromBase64String(tournament.Logo);
                        var tournamentImg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logo");
                        string fileName = "Img" + System.DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
                        var Filepath = Path.Combine(tournamentImg, fileName);
                        System.IO.File.WriteAllBytes(Filepath, imageBytes);
                        tournament.Logo = fileName;
                    }
                    _dbContext.Tournaments.Update(tournament);
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
