using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;
using MediatR;

namespace Company.Project.Application.Person.Commands.Delete
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private IDbContext DbContext { get; }
        private IMapper Mapper { get; }

        public DeletePersonCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var dbPerson = await DbContext.People.FindAsync(request.PersonId);
            DbContext.People.Remove(dbPerson);
            await DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
