using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlockbusterClone.Models
{
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        
        [BsonElement("synopsis")]
        public string Synopsis { get; set; } = string.Empty;
        
        [BsonElement("genre")]
        public string[] Genre { get; set; } = Array.Empty<string>();
        
        [BsonElement("director")]
        public string Director { get; set; } = string.Empty;

        [BsonElement("year")]
        public int Year { get; set; }
    }
}
