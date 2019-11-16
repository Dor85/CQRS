using System;
using MediatR;

namespace Company.Project.Application.Person.Commands.Create
{
    public class CreatePersonCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
    }
}
