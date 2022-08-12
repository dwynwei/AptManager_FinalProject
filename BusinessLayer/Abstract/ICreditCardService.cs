using Models.Entities;
using Models.MongoEntites;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICreditCardService<T> where T : class
    {
        public async Create(T card);
        public async Update(string id,T card);
        public async Delete(string id);
        public Get(ObjectId id);
        public Task<List<CreditCard>> Get();
    }
}
