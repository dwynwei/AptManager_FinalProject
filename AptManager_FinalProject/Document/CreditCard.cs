using Models.Document.DocumentBase;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class CreditCard:DocumentBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string CVC { get; set; }
        public decimal Balance { get; set; }
    }
}
