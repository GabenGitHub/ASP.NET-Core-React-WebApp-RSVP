using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RSVP_Web_app.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        List<Guest> Guests {get; set;} = new List<Guest>
        {
            new Guest()
            {
                _id = "12345",
                name = "Seri",
                participate = "yes",
                plusOne = true,
                plusOneName = "Zita"
            },
            new Guest()
            {
                _id = "1234",
                name = "Balazs",
                participate = "yes",
                plusOne = true,
                plusOneName = "Gyongyi"
            }
        };

        [HttpGet]
        [Route("guestList")]
        public IEnumerable<Guest> GuestList()
        {
            return Guests;
        }
    }

    public class Guest
    {
        public string _id {get; set;}
        public string name {get; set;}
        public string participate {get; set;}
        public bool plusOne {get; set;}
        public string plusOneName {get; set;}
    }
}