using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RSVP_Web_app.Models
{
    public class Guest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        public string participate { get; set; }

        public bool plusOne { get; set; }

        public string plusOneName { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime created { get; set; }

        [BsonElement("__v")]
        public Int32 mongooseVersion { get; set; }

        [BsonExtraElements]
        public BsonDocument CatchExtraElements { get; set; }
    }
}