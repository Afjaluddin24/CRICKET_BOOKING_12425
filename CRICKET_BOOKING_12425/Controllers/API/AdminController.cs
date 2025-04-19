using System.Security.AccessControl;
using CRICKET_BOOKING_12425.ApplicationContext;
using CRICKET_BOOKING_12425.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static CRICKET_BOOKING_12425.Models.AdminMaster;

namespace CRICKET_BOOKING_12425.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public AdminController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AdminRegistration")]
        public async Task<IActionResult> AdminRegistration(AdminMaster AdminMaster)
        {
            try
            {
                var ExistAdmins = await _dbContext.AdminMasters
                  .Where(o => o.PhoneNo == AdminMaster.PhoneNo || o.Email == AdminMaster.Email)
                  .ToListAsync();

                List<string> error = new List<string>();

                if (ExistAdmins.Any(o => o.PhoneNo == AdminMaster.PhoneNo))
                {
                    error.Add("Contact No already exists.");
                }
                if (ExistAdmins.Any(o => o.Email == AdminMaster.Email))
                {
                    error.Add("Email Id already exists.");
                }

                if (error.Count == 0)
                {
                    _dbContext.AdminMasters.Add(AdminMaster);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Registration Successfully" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = error });
                }

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpPost]
        [Route("Authentication")]

        public async Task<IActionResult> Login(Authentication Model)
        {
            try
            {
                var Data = await _dbContext.AdminMasters.Where(o => o.Name == Model.Name && o.Password == Model.Password).Select(o => new
                {
                    o.Name,
                    o.FullName,
                    o.Email,
                    o.PhoneNo,
                    o.Logo,
                    o.AdminMasterId
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

        [HttpGet]
        [Route("ClubDisplay")]

        public async Task<IActionResult> ClubDisplay(int? AdminMasterId)
        {
            try
            {
                var Data = await _dbContext.AdminMasters.ToListAsync();

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
        [Route("Getdetals/{AdminMasterId?}")]

        public async Task<IActionResult> Getdetals(int? AdminMasterId)
        {
            try
            {
                var Data = await _dbContext.AdminMasters.Where(o => o.AdminMasterId == AdminMasterId).FirstOrDefaultAsync();

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

        [HttpPost]
        [Route("AdminUpdate")]
        public async Task<IActionResult> AdminUpdate(AdminMaster AdminMaster)
        {
            try
            {
                var existingAdmin = await _dbContext.AdminMasters.FindAsync(AdminMaster.AdminMasterId);
                if (existingAdmin == null)
                {
                    return NotFound(new { Status = "Fail", Result = "Admin not found" });
                }

                // Update only the allowed fields
                existingAdmin.Name = AdminMaster.Name;
                existingAdmin.FullName = AdminMaster.FullName;
                existingAdmin.CubName = AdminMaster.CubName;
                existingAdmin.Email = AdminMaster.Email;
                existingAdmin.PhoneNo = AdminMaster.PhoneNo;
                existingAdmin.Location = AdminMaster.Location;
                existingAdmin.Map = AdminMaster.Map;
                existingAdmin.Address = AdminMaster.Address;
                existingAdmin.City = AdminMaster.City;
                existingAdmin.State = AdminMaster.State;

                // Handle logo separately
                if (!string.IsNullOrEmpty(AdminMaster.Logo))
                {
                    byte[] imageBytes = Convert.FromBase64String(AdminMaster.Logo);
                    var logoFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logo");

                    if (!Directory.Exists(logoFolder))
                    {
                        Directory.CreateDirectory(logoFolder);
                    }

                    string fileName = "Img" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
                    var filePath = Path.Combine(logoFolder, fileName);
                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    existingAdmin.Logo = fileName;
                }

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
