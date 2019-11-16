using System;
using System.Threading.Tasks;
using Company.Project.Application.Person.Commands;
using Company.Project.Application.Person.Queries.GetPersonList;
using Microsoft.AspNetCore.Mvc;

namespace Company.Project.Api.Controllers
{
    public class PeopleController : BaseController
    {

        [HttpGet("")]
        public async Task<ActionResult<PersonListViewModel>> GetPeopleList()
        {
            return Ok(await Mediator.Send(new GetPersonListQuery()));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePerson([FromBody]CreatePersonCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
    }
}
