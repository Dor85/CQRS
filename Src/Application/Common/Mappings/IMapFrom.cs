using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Company.Project.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
