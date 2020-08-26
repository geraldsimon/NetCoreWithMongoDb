using System;

namespace Mongo.Domain.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}