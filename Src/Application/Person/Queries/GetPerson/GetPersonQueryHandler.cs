using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Application.Person.Queries.Models;
using MediatR;

namespace Company.Project.Application.Person.Queries.GetPerson
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonLookupDto>
    {
        public IDbContext DbContext { get; set; }
        public IMapper Mapper { get; set; }

        public GetPersonQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<PersonLookupDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await DbContext.People.FindAsync(request.PersonId);

            return Mapper.Map<PersonLookupDto>(person);
        }
    }
}
