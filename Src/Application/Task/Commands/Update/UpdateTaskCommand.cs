using System;
using Company.Project.Application.Task.Queries.Models;
using Company.Project.Domain.Enums;
using MediatR;

namespace Company.Project.Application.Task.Commands.Update
{
    public class UpdateTaskCommand : IRequest<TaskDto>
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public TaskEnum Status { get; set; }
        public int ResposableId { get; set; }
        public int AssignedId { get; set; }
    }
}
