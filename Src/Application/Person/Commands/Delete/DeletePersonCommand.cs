using System;
using MediatR;

namespace Company.Project.Application.Person.Commands.Delete
{
    public class DeletePersonCommand : IRequest
    {
        public int PersonId { get; set; }

        public DeletePersonCommand(int id)
        {
            PersonId = id;
        }
    }
}
