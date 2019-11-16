using System;
using AutoMapper;
using Company.Project.Application.Common.Mappings;
using Company.Project.Domain.Enums;
using TaskEntity = Company.Project.Domain.Entities.Task;

namespace Company.Project.Application.Task.Queries.Models
{
    public class TaskDto : IMapFrom<TaskEntity>
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Resposable { get; set; }
        public string Assigned { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaskEntity, TaskDto>()
                .ForMember(m => m.TaskId, e => e.MapFrom(p => p.Id))
                .ForMember(m => m.Status, e => e.MapFrom(p => p.Status.ToString()))
                .ForMember(m => m.Resposable, e => e.MapFrom(p => p.GetResponsableName()))
                .ForMember(m => m.Assigned, e => e.MapFrom(p => p.GetAssigneeName()));
        }
    }
}
