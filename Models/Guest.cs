using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RSVP_Web_app.Models
{
    public class Guest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        
        // [JsonProperty("Name")]
        public string name { get; set; }

        [BsonDefaultValue("")]
        public string participate { get; set; }

        public bool plusOne { get; set; }

        [BsonDefaultValue("")]
        public string plusOneName { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime created { get; set; }
            
        [BsonElement("__v")]
        public Int32 mongooseVersionKey { get; set; }

        [BsonExtraElements]
        public BsonDocument CatchExtraElements { get; set; }
    }
}