using Company.Project.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Project.Application.Data.SeedData
{
    public class SeedDataCommand : IRequest
    {
    }

    public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand>
    {
        private IDbContext DbContext { get; }


        public SeedDataCommandHandler(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<Unit> Handle(SeedDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new DataSeeder(DbContext);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
