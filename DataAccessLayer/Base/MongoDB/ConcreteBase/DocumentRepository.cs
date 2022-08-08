using DataAccessLayer.Base.MongoDB.AbstractBase;
using Models.Document.DocumentBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace DataAccessLayer.Base.MongoDB.ConcreteBase
{
    public class DocumentRepository<T> : IDocumentRepository<T> where T : DocumentBaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        protected DocumentRepository(MongoClient mongoClient, IConfiguration configuration, string collectionName)
        {
            var db = mongoClient.GetDatabase(configuration.GetSection("MongoDatabase").Value);
            _collection = db.GetCollection<T>(collectionName);
        }

        public void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public void Delete(ObjectId id)
        {
            _collection.FindOneAndDelete(x=>x.Id == id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _collection.Find(expression).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _collection.AsQueryable() : _collection.AsQueryable().Where(expression);
        }

        public T GetById(string id)
        {
            return null;
        }

        public void Update(T entity)
        {
            _collection.FindOneAndReplace(x=>x.Id == entity.Id, entity);
        }
    }
}
