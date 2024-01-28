using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinebus.Models;

namespace onlinebus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusInventoryController : ControllerBase
    {
        private readonly onlinebookingContext _context;
        public BusInventoryController(onlinebookingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var busdetails = _context.BusInventories.ToList();
            return Ok(busdetails);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var busdetail = _context.BusInventories.Find(id);
                if (busdetail == null)
                {
                    return NotFound($"busdeatils not found with id {id}");
                }
                return Ok(busdetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(BusInventory businventory)
        {
            _context.Add(businventory);
            _context.SaveChanges();
            return Ok("Bus Details Created");
        }
        [HttpPut]
        public IActionResult Put(BusInventory businventory)
        {
            if (businventory == null || businventory.BookingId == 0)
            {
                if (businventory == null)
                {
                    return BadRequest("invalid BookingId");
                }
                else if (businventory.BookingId == 0)
                {
                    return BadRequest($"Booking id {businventory.BookingId} is invalid");
                }
            }

            var busdetail = _context.BusInventories.Find(businventory.BookingId);
            if (busdetail == null)
            {
                return NotFound($"BusDetails not found with bookingid {businventory.BookingId}");
            }
            busdetail.BusName = businventory.BusName;
            busdetail.BusCategory = businventory.BusCategory;
            busdetail.AvailabilitySeats = businventory.AvailabilitySeats;
            busdetail.Boarding = businventory.Boarding;
            busdetail.Departure = businventory.Departure;
            busdetail.StartTime = businventory.StartTime;
            busdetail.EndTime = businventory.EndTime;
            busdetail.Price = businventory.Price;
            _context.SaveChanges();
            return Ok("BusDetails Updated");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var busdetail = _context.BusInventories.Find(id);
                if (busdetail == null)
                {
                    return NotFound($"BusDetails not found with BookingId {id}");
                }
                _context.BusInventories.Remove(busdetail);
                _context.SaveChanges();
                return Ok("Busdetails deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

