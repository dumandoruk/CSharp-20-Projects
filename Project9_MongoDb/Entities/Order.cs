using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project9_MongoDb.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("OrderID")]
        public string OrderID{ get; set; }
        public string CustomerName{ get; set; }
        public string City{ get; set; }
        public string District{ get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalPrice{ get; set; }
    }
}
