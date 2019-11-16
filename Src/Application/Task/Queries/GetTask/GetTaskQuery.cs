using System;
using Company.Project.Application.Task.Queries.Models;
using MediatR;

namespace Company.Project.Application.Task.Queries.GetTask
{
    public class GetTaskQuery : IRequest<TaskDto>
    {
        public int TaskId { get; set; }

        public GetTaskQuery(int id)
        {
            TaskId = id;
        }
    }
}
