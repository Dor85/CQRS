using System;
using Company.Project.Application.Person.Queries.Models;
using MediatR;

namespace Company.Project.Application.Person.Queries.GetPerson
{
    public class GetPersonQuery : IRequest<PersonLookupDto>
    {
        public int PersonId { get; }

        public GetPersonQuery(int id)
        {
            PersonId = id;
        }
    }
}
