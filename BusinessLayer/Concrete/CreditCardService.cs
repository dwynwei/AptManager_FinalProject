using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Models.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardService(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public void Add(CreditCard model)
        {
            _creditCardRepository.Add(model);
        }

        public void Delete(ObjectId id)
        {
            _creditCardRepository.Delete(id);
        }

        public CreditCard Get(ObjectId id)
        {
            return _creditCardRepository.Get(x=>x.Id == id);
        }

        public IEnumerable<CreditCard> GetAll()
        {
            return _creditCardRepository.GetAll();
        }

        public CreditCard GetById(ObjectId id)
        {
            return null;
        }

        public void Update(CreditCard model)
        {
            _creditCardRepository.Update(model);
        }
    }
}
