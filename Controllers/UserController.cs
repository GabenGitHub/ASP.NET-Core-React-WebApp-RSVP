using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RSVP_Web_app.Services;
using RSVP_Web_app.Models;

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
        [Route("guestList")]
        public ActionResult<List<Guest>> Get() =>
            _guestService.Get();
    }
}