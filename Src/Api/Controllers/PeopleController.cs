using System;
using System.Threading.Tasks;
using Company.Project.Application.Person.Commands;
using Company.Project.Application.Person.Queries.GetPerson;
using Company.Project.Application.Person.Queries.GetPersonList;
using Company.Project.Application.Person.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Project.Api.Controllers
{
    public class PeopleController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<PersonListViewModel>> GetPersonList()
        {
            return Ok(await Mediator.Send(new GetPersonListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonListViewModel>> GetPerson(int id)
        {
            return Ok(await Mediator.Send(new GetPersonQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody]CreatePersonCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
    }
}
