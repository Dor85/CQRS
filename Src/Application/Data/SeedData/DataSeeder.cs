using Company.Project.Application.Common.Interfaces;
using Company.Project.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PersonEntity = Company.Project.Domain.Entities.Person;

namespace Company.Project.Application.Data.SeedData
{
    public class DataSeeder
    {
        private IDbContext DbContext { get; }

        public DataSeeder(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (DbContext.People.Any())
            {
                return;
            }

            await SeedPersonsAsync(cancellationToken);
        }

        private async Task SeedPersonsAsync(CancellationToken cancellationToken)
        {
            var Persons = new[]
            {
                new PersonEntity { FirstName = "Maria", LastName = "Lincoln", Dob = new DateTime(1975,06,23), Address = (Address)"Calle Blanca, Barcelona, Cataluña, España, 08030"},
                new PersonEntity { FirstName = "Antonio", LastName = "Cruz", Dob = new DateTime(1982,03,21), Address = (Address)"35 King George, London, London, United Kindom, 04698" },
                new PersonEntity { FirstName = "Anna", LastName = "Brown", Dob = new DateTime(1969,08,13), Address = (Address)"Rua Orós 92, Sao Paulo, , Brazil, 12345"},
                new PersonEntity { FirstName = "Martín", LastName = "Moreno", Dob = new DateTime(1990,11,30), Address = (Address)"Via Monte Bianco 34, Torino, , Italy, 98765"},
                new PersonEntity { FirstName = "Pedro", LastName = "Afonso", Dob = new DateTime(1978,04,12), Address = (Address)"Jardim das rosas n. 32, Lisboa, , Prtugal, 65412"}
            };

            DbContext.People.AddRange(Persons);

            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
