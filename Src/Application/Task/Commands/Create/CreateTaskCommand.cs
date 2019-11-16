using System;
using Company.Project.Domain.Enums;
using MediatR;

namespace Company.Project.Application.Task.Commands.Create
{
    public class CreateTaskCommand : IRequest
    {
        public string Title { get; set; }
        public TaskEnum Status { get; set; }
        public int ResposableId { get; set; }
        public int AssignedId { get; set; }
    }
}
