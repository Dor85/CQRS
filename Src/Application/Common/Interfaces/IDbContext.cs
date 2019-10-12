using Company.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PersonEntity = Company.Project.Domain.Entities.Person;
using TaskEntity = Company.Project.Domain.Entities.Task;


namespace Company.Project.Application.Common.Interfaces
{
    public interface IDbContext
    {
        DbSet<PersonEntity> People { get; set; }
        DbSet<TaskEntity> Tasks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
