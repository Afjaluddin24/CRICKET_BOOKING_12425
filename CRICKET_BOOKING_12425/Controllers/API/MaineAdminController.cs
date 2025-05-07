using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CRICKET_BOOKING_12425.Models.MaineAdmin;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaineAdminController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public MaineAdminController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> AddBookingLime(MaineAdmin mainAdmin)
        {
            try 
            {
                _dbContext.MaineAdmins.Add(mainAdmin);
                await _dbContext.SaveChangesAsync();
                return Ok(new { Status = "Ok", Result = "Save Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }


        [HttpPost]
        [Route("AuthenticationMaine")]

        public async Task<IActionResult> Login(MainAdmin Model)
        {
            try
            {
                var Data = await _dbContext.MaineAdmins.Where(o => o.Name == Model.Name && o.Password == Model.Password).Select(o => new
                {
                    o.Name,
                    o.FullName,
                    o.Email,
                    o.PhoneNo,
                    o.Logo,
                    o.MapAdress,
                    o.Adress,
                    o.MaineAdminId,
                }).FirstOrDefaultAsync();

                if (Data != null)
                {
                    return Ok(new { Status = "Ok", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Match" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }
    }
}
