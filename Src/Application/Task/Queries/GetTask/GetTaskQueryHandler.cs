using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Application.Task.Queries.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Company.Project.Application.Task.Queries.GetTask
{
    public class GetTaskQueryHandler : TaskBaseCommandQueryHandler, IRequestHandler<GetTaskQuery, TaskDto>
    {
        public GetTaskQueryHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<TaskDto> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            var dbTask = await DbContext.Tasks
                .Include(t => t.Responsable)
                .Include(t => t.Assigned)
                .FirstOrDefaultAsync(t => t.Id == request.TaskId);

            return Mapper.Map<TaskDto>(dbTask);
        }
    }
}
