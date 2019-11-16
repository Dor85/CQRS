using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;
using TaskEntity = Company.Project.Domain.Entities.Task;
using MediatR;
using System.Data.Common;
using Company.Project.Application.Task.Queries.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Project.Application.Task.Commands.Update
{
    public class UpdateTaskCommandHandler : TaskBaseCommandQueryHandler, IRequestHandler<UpdateTaskCommand, TaskDto>
    {
        public UpdateTaskCommandHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var dbTask = await DbContext.Tasks
                .Include(t => t.Responsable)
                .Include(t => t.Assigned)
                .FirstOrDefaultAsync(t => t.Id == request.TaskId);
            UpdateDbTask(dbTask, request);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Mapper.Map<TaskDto>(dbTask);
        }

        private void UpdateDbTask(TaskEntity taskEntity, UpdateTaskCommand updateTask)
        {
            taskEntity.Title = updateTask.Title;
            taskEntity.Status = updateTask.Status;
            taskEntity.ResponsableId = updateTask.ResposableId;
            taskEntity.AssignedId = updateTask.AssignedId;
        }
    }
}
