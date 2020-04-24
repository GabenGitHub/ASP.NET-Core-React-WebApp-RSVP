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
    [Route("api/guests")]
    public class UserController : ControllerBase
    {
        private readonly GuestService _guestService;

        public UserController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Guest>>> Get()
        {
            try
            {
                return await _guestService.Get();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("check")]
        public async Task<ActionResult<Guest>> CheckGuest([FromBody]Guest guestIn)
        {
            try
            {
                var guest = await _guestService.GetByName(guestIn.name);

                 if(guest == null)
                {
                    return NotFound("Not found");
                }

                return Ok(guest);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            } 
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Update([FromBody]Guest guestIn)
        {
            try
            {
                var guest = await _guestService.GetByGuestIn(guestIn._id);

                if (guest == null)
                {
                    return NotFound("Guest not found");
                }

                guest.participate = guestIn.participate;
                guest.plusOne = guestIn.plusOne;
                guest.plusOneName = guestIn.plusOneName;

                // checking plus one
                if (guestIn.participate == "no" || guestIn.plusOne == false)
                {
                    guest.plusOne = false;
                    guest.plusOneName = "";
                }

                await _guestService.Update(guestIn._id, guest);

                var guestList = await _guestService.Get();

                return Ok(guestList);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}