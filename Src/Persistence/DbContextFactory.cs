using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Company.Project.Persistence
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<TaskDbContext>
    {
        protected override TaskDbContext CreateNewInstance(DbContextOptions<TaskDbContext> options)
        {
            return new TaskDbContext(options);
        }
    }
}
