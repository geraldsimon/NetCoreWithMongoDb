using Microsoft.Extensions.Options;
using Mongo.Data.Context;
using Mongo.Domain.Intefaces;
using Mongo.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mongo.Data.Repository
{
    public partial class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly MongoContext context = null;
        public Repository(IOptions<Settings> settings)
        {
            context = new MongoContext(settings);
        }

        public async Task Add(TEntity entity)
        {
            await context.GetCollection<TEntity>().InsertOneAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return context.GetCollection<TEntity>().AsQueryable<TEntity>().ToList();
        }

        public async Task<TEntity> GetById(string Id)
        {
            var entity = Builders<TEntity>.Filter.Eq("Id", Id);
            return await context.GetCollection<TEntity>().Find(entity).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByName(string Name)
        {
            var entity = Builders<TEntity>.Filter.Eq("Name", Name);
            var collection = context.GetCollection<TEntity>().Find(entity).FirstOrDefaultAsync();

            return await collection;
        }

        public async Task<DeleteResult> Remove(string Id)
        {
            return await context.GetCollection<TEntity>().DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", Id));
        }

        public async Task<string> Upadate(Guid id, TEntity entity)
        {
            await context.GetCollection<TEntity>().ReplaceOneAsync(zz => zz.Id == id, entity);
            return string.Empty;
        }

        public Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}