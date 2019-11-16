using AutoMapper;
using Company.Project.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;
using PersonEntity = Company.Project.Domain.Entities.Person;

namespace Company.Project.Application.Person.Queries.Models
{
    public class PersonLookupDto : IMapFrom<PersonEntity>
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonEntity, PersonLookupDto>()
                .ForMember(m => m.Name, e => e.MapFrom(p => p.GetFullName()))
                .ForMember(m => m.Address, e => e.MapFrom(p => p.Address.ToString()));
        }
    }
}
