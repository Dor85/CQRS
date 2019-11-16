using System;
using Company.Project.Application.Person.Queries.Models;
using MediatR;

namespace Company.Project.Application.Person.Commands.Update
{
    public class UpdatePersonCommand : IRequest<PersonLookupDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
    }
}
