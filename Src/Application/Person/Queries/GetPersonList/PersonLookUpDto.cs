using AutoMapper;
using Company.Project.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;
using PersonEntity = Company.Project.Domain.Entities.Person;

namespace Company.Project.Application.Person.Queries.GetPersonList
{
    public class PersonLookupDto : IMapFrom<PersonEntity>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonEntity, PersonLookupDto>()
                .ForMember(m => m.Name, e => e.MapFrom(p => p.GetFullName()));
        }
    }
}
