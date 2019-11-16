using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Application.Task.Queries.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.Project.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : TaskBaseCommandQueryHandler, IRequestHandler<GetTaskListQuery, TaskListViewModel>
    {
        public GetTaskListQueryHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<TaskListViewModel> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var taskDtoList = await DbContext.Tasks
                .Include(t => t.Responsable)
                .Include(t => t.Assigned)
                .ProjectTo<TaskDto>(Mapper.ConfigurationProvider)
                .ToListAsync();

            return new TaskListViewModel { Tasks = taskDtoList };
        }
    }
}
