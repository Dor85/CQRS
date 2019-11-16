using System;
using System.Threading;
using System.Threading.Tasks;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Domain.ValueObjects;
using MediatR;
using PersonEntity = Company.Project.Domain.Entities.Person;

namespace Company.Project.Application.Person.Commands.Create
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        public IDbContext DbContext { get; }

        public CreatePersonCommandHandler(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new PersonEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Dob = request.Dob,
                Address = (Address)request.Address
            };

            await DbContext.People.AddAsync(person);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
