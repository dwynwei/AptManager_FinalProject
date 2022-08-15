using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Configuration.Validator.CreditCardRequest;
using DataAccessLayer.Abstract;
using DataTransferObject.CreditCard;
using BusinessLayer.Configuration.Exception;
using FluentValidation;
using Microsoft.Extensions.Options;
using Models.Entities;
using Models.MongoEntites;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    /*
     * CreditCard Service
     */
    public class CreditCardService
    {
        private readonly IMongoCollection<CreditCard> _mongoCollection;
        private readonly IMapper _mapper;

        public CreditCardService(IOptions<MongoSettings> options, IMapper mapper)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _mongoCollection = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<CreditCard>(options.Value.CollectionName);
            _mapper = mapper;
        }

        public async Task<List<CreditCard>> Get()
        {
            return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<CreditCard> GetbyId(string id)
        {
            return await _mongoCollection.Find(x => x.Id == new ObjectId(id)).FirstOrDefaultAsync();
        }

        public async Task Create(CreateCreditCardRequest card)
        {
            var validator = new CreateCreditCardRequestValidator();
            validator.Validate(card).ThrowIfException();

            var entity = _mapper.Map<CreditCard>(card);

            await _mongoCollection.InsertOneAsync(entity);
        }

        public async Task Update(string id, UpdateCreditCardRequest card)
        {
            var validator = new UpdateCreditCardRequestValidator();
            validator.Validate(card).ThrowIfException();

            var entity = _mapper.Map<CreditCard>(card);
            await _mongoCollection.ReplaceOneAsync(x => x.Id == new ObjectId(id), entity);
        }

        public async Task Delete(string id)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id == new ObjectId(id));
        }
    }
}
