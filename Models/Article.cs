using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FamilyOrgaBack.Models
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}
        [BsonElement("article_name")]
        public string article_name {get; set;}
        public string amount {get; set;}
        public string note {get; set;}

    }
}