using Company.Project.Domain.Common;
using Company.Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Company.Project.Domain.Entities
{
    public class Person : AuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public Address Address { get; set; }
        public Person Partner { get; set; }

        public ICollection<Task> Tasks { get; }

        public Person()
        {
            Tasks = new HashSet<Task>();
        }

        public string GetFullName()
        {
            return $"{LastName}, {FirstName}";
        }

        public string GetMailingAddress()
        {
            return $"Deliver to: {Address.ToString()}";
        }
    }
}
