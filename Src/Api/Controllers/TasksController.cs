using System;
using System.Threading.Tasks;
using Company.Project.Application.Task.Commands.Create;
using Company.Project.Application.Task.Commands.Delete;
using Company.Project.Application.Task.Commands.Update;
using Company.Project.Application.Task.Queries.GetTask;
using Company.Project.Application.Task.Queries.GetTaskList;
using Company.Project.Application.Task.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Project.Api.Controllers
{
    public class TasksController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TaskListViewModel>> GetTaskList()
        {
            return Ok(await Mediator.Send(new GetTaskListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            return Ok(await Mediator.Send(new GetTaskQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody]CreateTaskCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<TaskDto>> UpdateTask([FromBody]UpdateTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            return Ok(await Mediator.Send(new DeleteTaskCommand(id)));
        }
    }
}
