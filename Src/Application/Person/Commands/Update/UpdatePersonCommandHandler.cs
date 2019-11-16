using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Application.Person.Queries.Models;
using PersonEntity = Company.Project.Domain.Entities.Person;
using MediatR;
using Company.Project.Domain.ValueObjects;

namespace Company.Project.Application.Person.Commands.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonLookupDto>
    {
        private IDbContext DbContext { get; }
        private IMapper Mapper { get; }

        public UpdatePersonCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<PersonLookupDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var dbPerson = await DbContext.People.FindAsync(request.Id);
            UpdateDbPersonData(dbPerson, request);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Mapper.Map<PersonLookupDto>(dbPerson);
        }

        private void UpdateDbPersonData(PersonEntity personEntity, UpdatePersonCommand personCommand)
        {
            personEntity.FirstName = personCommand.FirstName;
            personEntity.LastName = personCommand.LastName;
            personEntity.Dob = personCommand.Dob;
            personEntity.Address = (Address)personCommand.Address;

        }

    }
}
