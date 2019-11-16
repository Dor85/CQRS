using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;
using TaskEntity = Company.Project.Domain.Entities.Task;
using MediatR;

namespace Company.Project.Application.Task.Commands.Create
{
    public class CreateTaskCommandHandler : TaskBaseCommandQueryHandler, IRequestHandler<CreateTaskCommand>
    {
        public CreateTaskCommandHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskEntity = new TaskEntity
            {
                Title = request.Title,
                Status = Domain.Enums.TaskEnum.Open,
                ResponsableId = request.ResposableId,
                AssignedId = request.AssignedId
            };
            await DbContext.Tasks.AddAsync(taskEntity);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
