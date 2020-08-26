using Microsoft.Extensions.Options;
using Mongo.Data.Context;
using Mongo.Domain.Intefaces;
using Mongo.Domain.Models;

namespace Mongo.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IOptions<Settings> settings) : base(settings) { }
    }
}