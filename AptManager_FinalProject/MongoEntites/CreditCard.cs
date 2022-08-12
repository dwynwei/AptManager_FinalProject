using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MongoEntites
{
    public class CreditCard
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string ExpireDate { get; set; }
        public decimal Balance { get; set; } = 2000;
    }
}
