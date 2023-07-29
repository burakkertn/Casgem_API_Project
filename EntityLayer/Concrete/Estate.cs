using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Estate
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("room")]
        public int Room { get; set; }

        [BsonElement("buildyear")]
        public string BuildYear { get; set; }

        [BsonElement("des")]
        public string Des { get; set; }

        [BsonElement("imageurl")]
        public string ImageURL { get; set; }
    }
}
