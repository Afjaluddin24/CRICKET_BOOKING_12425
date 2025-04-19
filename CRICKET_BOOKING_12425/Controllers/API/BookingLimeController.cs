using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingLimeController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public BookingLimeController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AddBookingLime")]
        public async Task<IActionResult> AddBookingLime(BookingLimet BookingLimet)
        {
            try
            {
                if (BookingLimet == null)
                {
                    return Ok(new { Status = "Fail", Result = "Invalid data." });
                }

                _dbContext.BookingsLimets.Add(BookingLimet);
                await _dbContext.SaveChangesAsync();

                return Ok(new { Status = "Ok", Result = "Save Successfully" });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("getBookingLime/{AdminMasterId?}")]
        public async Task<IActionResult> getBookingLime(int? AdminMasterId)
        {
            try
            {
                var Data = await _dbContext.BookingsLimets.Where(o=>o.AdminMasterId == AdminMasterId).ToListAsync();

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
        [Route("ListBookingLime/{BookingLimetId?}")]
        public async Task<IActionResult> ListBookingLime(int? BookingLimetId)
        {
            try
            {
                var data = await _dbContext.BookingsLimets.FindAsync(BookingLimetId);
                if (data == null)
                {
                    return NotFound(new { Status = "Not Found", Message = $"No record with Id = {BookingLimetId}" });
                }
                return Ok(new { Status = "Ok", Result = data });

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("DeleteBookingLime/{BookingLimetId?}")]
        public async Task<IActionResult> DeleteBookingLime(int? BookingLimetId)
        {
            try
            {
                var Data =_dbContext.BookingsLimets.Find(BookingLimetId);
                if(Data != null)
                {
                    _dbContext.BookingsLimets.Remove(Data);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Delete Successfully" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Try Agen Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }
        [HttpPost]
        [Route("UpdateBookingLime")]
        public async Task<IActionResult> UpdateBookingLime(BookingLimet BookingLimet)
        {
            try
            {
                if (BookingLimet == null)
                {
                    return Ok(new { Status = "Fail", Result = "Invalid data." });
                }
                _dbContext.BookingsLimets.Update(BookingLimet);
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
