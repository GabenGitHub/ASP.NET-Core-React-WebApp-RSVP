namespace RSVP_Web_app.Models
{
    public class GuestsDatabaseSettings : IGuestsDatabaseSettings
    {
        public string GuestsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGuestsDatabaseSettings
    {
        string GuestsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}