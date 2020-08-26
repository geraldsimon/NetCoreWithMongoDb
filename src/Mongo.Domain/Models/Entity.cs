using System;

namespace Mongo.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
        public DateTime DateRegister { get; private set; }
        public DateTime DateUpdate { get; private set; }
        public bool Active { get; private set; }
    }
}