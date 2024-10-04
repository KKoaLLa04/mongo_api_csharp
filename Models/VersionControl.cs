using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo.Models
{
    public class VersionControl
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public int Version { get; set; }
    }
}