using Microsoft.Extensions.Options;
using Mongo.Domain.Models;
using MongoDB.Driver;

namespace Mongo.Data.Context
{
    public class MongoContext
    {    
        public IMongoDatabase database = null;

        public MongoContext(IOptions<Settings> settings)
        { 
            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
                database = client.GetDatabase(settings.Value.DataBase);
        }


        public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : Entity
        {
            return database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}