using System;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;

namespace Company.Project.Application.Task
{
    public abstract class TaskBaseCommandQueryHandler
    {
        protected IDbContext DbContext { get; }

        protected IMapper Mapper { get; }

        public TaskBaseCommandQueryHandler(IDbContext context, IMapper mapper)
        {
            DbContext = context;
            Mapper = mapper;
        }
    }
}
