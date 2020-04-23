using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using RSVP_Web_app.Models;

namespace RSVP_Web_app.Services
{
    public class GuestService
    {
        private readonly IMongoCollection<Guest> _guests;

        public GuestService(IGuestsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _guests = database.GetCollection<Guest>(settings.GuestsCollectionName);
        }

        public async Task<List<Guest>> Get()
        {
            var gettingGuests = await _guests.FindAsync(guest => true);
            return gettingGuests.ToList();
        }

        public async Task<Guest> GetByName(string name)
        {
            var foundGuestByName = await _guests.FindAsync<Guest>(guest => guest.name.ToLower() == name.ToLower());
            var foundGuestFirstOrDefault = await foundGuestByName.FirstOrDefaultAsync();
            return foundGuestFirstOrDefault;
        }

        public async Task<Guest> GetByGuestIn(string id)
        {
            var foundGuestByName = await _guests.FindAsync<Guest>(guest => guest._id == id);
            var foundGuestFirstOrDefault = await foundGuestByName.FirstOrDefaultAsync();
            return foundGuestFirstOrDefault;
        }

        public async Task<Guest> Create(Guest guest)
        {
            await _guests.InsertOneAsync(guest);
            return guest;
        }

        public async Task Update(string id, Guest guestIn) =>
            await _guests.ReplaceOneAsync(guest => guest._id == id, guestIn);

        public async Task Remove(string id) =>
            await _guests.DeleteOneAsync(guest => guest._id == id);
    }
}