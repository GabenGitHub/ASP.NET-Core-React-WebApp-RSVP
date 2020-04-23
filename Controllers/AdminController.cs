using Microsoft.AspNetCore.Mvc;
using RSVP_Web_app.Services;
using RSVP_Web_app.Models;
using System;
using System.Threading.Tasks;

namespace RSVP_Web_app.Controllers
{
    [ApiController]
    [Route("api")]
    public class AdminController : ControllerBase
    {
        private readonly GuestService _guestService;

        public AdminController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpPost("addGuest")]
        public async Task<ActionResult<Guest>> Create([FromBody]Guest guest)
        {
            if(guest == null)
            {
                return BadRequest();
            }

            // TODO: check name to avoid duplicates (for deletion)

            // Empty strings come as null 
            guest.participate = "";
            guest.plusOneName = "";
            guest.created = DateTime.Now;

            await _guestService.Create(guest);

            return Ok(guest);
        }

        [HttpDelete("removeGuest")]
        public async Task<IActionResult> Delete([FromBody]Guest guestIn)
        {
            var guest = await _guestService.GetByName(guestIn.name);

            if (guest == null)
            {
                return NotFound("Not found");
            }

            await _guestService.Remove(guest._id);

            return Ok(guest);
        }
    }
}