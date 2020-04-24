using Microsoft.AspNetCore.Mvc;
using RSVP_Web_app.Services;
using RSVP_Web_app.Models;
using System;
using System.Threading.Tasks;

namespace RSVP_Web_app.Controllers
{
    [ApiController]
    [Route("api/guests")]
    public class AdminController : ControllerBase
    {
        private readonly GuestService _guestService;

        public AdminController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Guest>> Create([FromBody]Guest guest)
        {
            try
            {
                if(guest == null || string.IsNullOrWhiteSpace(guest.name))
                {
                    return BadRequest("Cannot be empty or white space");
                }

                // avoiding duplicates
                var checkGuestIfExist = await _guestService.GetByName(guest.name);
                if(checkGuestIfExist != null)
                {
                    return BadRequest("Guest already exist.");
                }

                // Empty strings come as null 
                guest.participate = "";
                guest.plusOneName = "";
                guest.created = DateTime.Now;

                await _guestService.Create(guest);

                return Ok(guest);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Delete([FromBody]Guest guestIn)
        {
            try
            {
                var guest = await _guestService.GetByName(guestIn.name);

                if (guest == null)
                {
                    return NotFound("Not found");
                }

                await _guestService.Remove(guest._id);

                return Ok(guest);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}