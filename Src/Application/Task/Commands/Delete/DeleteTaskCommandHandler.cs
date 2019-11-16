using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Company.Project.Application.Common.Interfaces;
using MediatR;

namespace Company.Project.Application.Task.Commands.Delete
{
    public class DeleteTaskCommandHandler : TaskBaseCommandQueryHandler, IRequestHandler<DeleteTaskCommand>
    {
        public DeleteTaskCommandHandler(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var dbTask = await DbContext.Tasks.FindAsync(request.TaskId);
            DbContext.Tasks.Remove(dbTask);
            await DbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
