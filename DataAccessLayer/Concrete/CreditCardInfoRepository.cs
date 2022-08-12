//using DataAccessLayer.Abstract;
//using DataAccessLayer.Base.MongoDB.ConcreteBase;
//using Microsoft.Extensions.Configuration;
//using Models.Entities;
//using MongoDB.Driver;
//using Models.Document;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccessLayer.Concrete
//{
//    public class CreditCardInfoRepository:DocumentRepository<CreditCard>,ICreditCardInfoRepository
//    {
//        private const string Collection = "CreditCard";

//        public CreditCardInfoRepository(MongoClient client, IConfiguration configuration, string collectionName) : base(client, configuration, collectionName)
//        {
//        }
//    }
//}
