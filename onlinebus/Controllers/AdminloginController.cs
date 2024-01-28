using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinebus.Models;

namespace onlinebus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminloginController : ControllerBase
    {
        private readonly onlinebookingContext _context;

        public AdminloginController(onlinebookingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var adminlogin = _context.Adminlogins.ToList();
            return Ok(adminlogin);
        }
        [HttpGet("{username}")]
        public IActionResult Get(String username)
        {
            var adminlogin = _context.Adminlogins.Find(username);
            if (adminlogin == null)
            {
                return NotFound();
            }
            return Ok(adminlogin);
        }

        [HttpPost]
        public IActionResult Post(Adminlogin adminlogin)
        {
            _context.Add(adminlogin);
            _context.SaveChanges();
            return Ok("Login created");
        }

        [HttpPut]
        public IActionResult Put(Adminlogin adminlogin)
        {
            //if (adminlogin == null || adminlogin.UserName == "")
            //{
            //    if (adminlogin == null)
            //    {
            //        return NotFound("invalid");
            //    }
            //    else if (adminlogin.UserName == "")
            //    {
            //        return BadRequest($"UserName {adminlogin.UserName} is invalid");
            //    }
            //}
            if (adminlogin.UserName == "")
            {
                return BadRequest($"UserName {adminlogin.UserName} is invalid");
            }
            var admin = _context.Adminlogins.Find(adminlogin.UserName);
            if (admin == null)
            {
                return NotFound($"Logindetails not found with Username {adminlogin.UserName}");
            }
            admin.UserName = adminlogin.UserName;
            admin.Password = adminlogin.Password;
            _context.SaveChanges();
            return Ok("Logindetails Updated");
        }

        [HttpDelete]
        public IActionResult Delete(string UserName)
        {
            var adminlogin = _context.Adminlogins.Find(UserName);
            if (adminlogin == null)
            {
                return NotFound($"Adminlogin not found with adminusername {UserName}");
            }
            _context.Adminlogins.Remove(adminlogin);
            _context.SaveChanges();
            return Ok("Adminlogin deleted");
        }
    }

}

