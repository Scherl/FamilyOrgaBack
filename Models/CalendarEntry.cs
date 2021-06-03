using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace FamilyOrgaBack.Models
{
    public class CalendarEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}
        [BsonElement("description")]
        public string description {get; set;}
        public bool isComplete {get; set;}
      
        public DateTime dates { get; set; }
       
        public string color {get; set;}

    }
}