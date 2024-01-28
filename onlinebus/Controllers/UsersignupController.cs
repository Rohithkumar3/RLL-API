using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinebus.Models;

namespace onlinebus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersignupController : ControllerBase
    {
        private readonly onlinebookingContext _context;

        public UsersignupController(onlinebookingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usersign = _context.Usersignups.ToList();
            return Ok(usersign);
        }

        [HttpGet("{username}")]
        public IActionResult Get(String username)
        {
            var usersign = _context.Usersignups.Find(username);
            if (usersign == null)
            {
                return NotFound();
            }
            return Ok(usersign);
        }

        [HttpPost]
        public IActionResult Post(Usersignup usersignup)
        {
            _context.Add(usersignup);
            _context.SaveChanges();
            return Ok("User created");
        }
        [HttpPut]
        public IActionResult Put(Usersignup usersignup)
        {
            if (usersignup.Username == "")
            {
                return BadRequest($"UserName {usersignup.Username} is invalid");
            }
            var details =_context.Usersignups.Find(usersignup.Username);
            if(details == null)
            {
                return NotFound($"Logindetails not found with Username {usersignup.Username}");
            }
            details.FullName = usersignup.FullName;
            details.Dob = usersignup.Dob;
            details.Mobile = usersignup.Mobile;
            details.Email = usersignup.Email;
            details.State = usersignup.State;
            details.City = usersignup.City;
            details.Pincode = usersignup.Pincode;
            details.Address = usersignup.Address;
            details.Username = usersignup.Username;
            details.Password = usersignup.Password;
            
            _context.SaveChanges();
            return Ok("Details Updated");
        }
        

        [HttpDelete]
        public IActionResult Delete(string username)
        {
            var usersign = _context.Usersignups.Find(username);
            if (usersign == null)
            {
                return NotFound($"user not found with username {username}");
            }
            _context.Usersignups.Remove(usersign);
            _context.SaveChanges();
            return Ok("User deleted");
        }


    }
}
