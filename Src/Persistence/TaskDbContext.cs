using Microsoft.EntityFrameworkCore;
using Company.Project.Application.Common.Interfaces;
using Company.Project.Common;
using System.Threading.Tasks;
using System.Threading;
using Company.Project.Domain.Common;
using Company.Project.Domain.Entities;

namespace Company.Project.Persistence
{
    public class TaskDbContext : DbContext, IDbContext
    {

        private ICurrentUserService CurrentUserService { get; }
        private IDateTime DateTime { get; }
        public DbSet<Person> People { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public TaskDbContext(DbContextOptions<TaskDbContext> options,
            ICurrentUserService currentService,
            IDateTime dateTime) : base(options)
        {
            CurrentUserService = currentService;
            DateTime = dateTime;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = CurrentUserService.GetUserId();
                    entry.Entity.Created = DateTime.Now;

                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = CurrentUserService.GetUserId();
                    entry.Entity.LastModified = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskDbContext).Assembly);
        }
    }
}