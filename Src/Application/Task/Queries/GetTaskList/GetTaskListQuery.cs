using System;
using Company.Project.Application.Task.Queries.Models;
using MediatR;

namespace Company.Project.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<TaskListViewModel>
    {
    }
}
