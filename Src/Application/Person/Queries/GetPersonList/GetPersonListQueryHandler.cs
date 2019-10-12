using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.Project.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Project.Application.Person.Queries.GetPersonList
{
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, PersonListViewModel>
    {
        private IMapper Mapper { get; }
        private IDbContext DbContext { get; }
        public GetPersonListQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
        public async Task<PersonListViewModel> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var persons = await DbContext.People
                .ProjectTo<PersonLookupDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var viewModel = new PersonListViewModel { Persons = persons };

            return viewModel;
        }
    }
}
