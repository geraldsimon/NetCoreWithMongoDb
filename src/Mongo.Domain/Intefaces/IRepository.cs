using Mongo.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mongo.Domain.Intefaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(string Id);
        Task<TEntity> GetByName(string Nome);
        Task<List<TEntity>> GetAllAsync();
        Task<string> Upadate(Guid id, TEntity entity);
        Task<DeleteResult> Remove(string id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
    }
}