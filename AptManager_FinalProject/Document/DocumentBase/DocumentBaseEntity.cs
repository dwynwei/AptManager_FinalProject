using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Document.DocumentBase
{
    public abstract class DocumentBaseEntity
    {
        public ObjectId Id { get; set; }
        public string ObjectId => Id.ToString();
    }
}
