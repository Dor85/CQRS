using System;
using MediatR;

namespace Company.Project.Application.Task.Commands.Delete
{
    public class DeleteTaskCommand : IRequest
    {
        public int TaskId { get; }

        public DeleteTaskCommand(int id)
        {
            TaskId = id;
        }
    }
}
