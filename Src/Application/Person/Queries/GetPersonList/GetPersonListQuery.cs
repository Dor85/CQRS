using Company.Project.Application.Person.Queries.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.Application.Person.Queries.GetPersonList
{
    public class GetPersonListQuery : IRequest<PersonListViewModel>
    {
    }
}
