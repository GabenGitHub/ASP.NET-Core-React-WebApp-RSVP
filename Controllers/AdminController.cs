using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RSVP_Web_app.Services;
using RSVP_Web_app.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public ActionResult<Guest> Create([FromBody]Guest guest)
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

            _guestService.Create(guest);

            return Ok(guest);
        }

        [HttpDelete("removeGuest")]
        public IActionResult Delete([FromBody]Guest guestIn)
        {
            var guest = _guestService.GetByName(guestIn.name);

            if (guest == null)
            {
                return NotFound();
            }

            _guestService.Remove(guest._id);

            return Ok(guest);
        }
    }
}