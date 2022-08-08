using Models.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICreditCardService
    {
        void Add(CreditCard model);
        void Update(CreditCard model);
        CreditCard Get(ObjectId id);
        CreditCard GetById(ObjectId id);
        IEnumerable<CreditCard> GetAll();
        void Delete(ObjectId id);
    }
}
