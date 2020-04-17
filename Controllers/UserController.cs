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
    public class UserController : ControllerBase
    {
        private readonly GuestService _guestService;

        public UserController(GuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        [Route("listGuests")]
        public ActionResult<List<Guest>> Get()
        {
            return _guestService.Get();
        }

        [HttpPost]
        [Route("checkGuest")]
        public ActionResult<Guest> CheckGuest([FromBody]Guest guestIn)
        {
            var guest = _guestService.GetByName(guestIn.name);

            if(guest == null)
            {
                return NotFound("Not found");
            }

            return Ok(guest);
        }

        [HttpPut("editGuest")]
        public IActionResult Update([FromBody]Guest guestIn)
        {
            var guest = _guestService.GetByGuestIn(guestIn._id);

            // TODO REFACTOR
            guest.participate = guestIn.participate;
            guest.plusOne = guestIn.plusOne;
            guest.plusOneName = guestIn.plusOneName;

            if (guest == null)
            {
                return NotFound();
            }

            _guestService.Update(guestIn._id, guest);

            var guestList = _guestService.Get();

            return Ok(guestList);
        }
    }
}