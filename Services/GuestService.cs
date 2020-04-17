using System.Collections.Generic;
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

        public List<Guest> Get() =>
            _guests.Find(guest => true).ToList();

        public Guest GetByName(string name)
        {
            return _guests.Find<Guest>(guest => guest.name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public Guest GetByGuestIn(string id)
        {
            return _guests.Find<Guest>(guest => guest._id == id).FirstOrDefault();
        }

        public Guest Create(Guest guest)
        {
            _guests.InsertOne(guest);
            return guest;
        }

        public void Update(string id, Guest guestIn)
        {
            _guests.ReplaceOne(guest => guest._id == id, guestIn);
        }

        public void Remove(Guest guestIn) =>
            _guests.DeleteOne(guest => guest._id == guestIn._id);

        public void Remove(string id) =>
            _guests.DeleteOne(guest => guest._id == id);
    }
}