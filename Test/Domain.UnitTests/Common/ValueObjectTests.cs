using System;
using Company.Project.Domain.ValueObjects;
using Xunit;

namespace Company.Project.Domain.UnitTests.Common
{
    public class ValueObjectTests
    {
        [Fact]
        public void Equals_given_different_values_should_return_false()
        {
            // Arrange
            var address1 = new Address("Balmes", "Barcelona", "Cataluña", "España", "08025");
            var address2 = new Address("Corsega", "Barcelona", "Cataluña", "España", "08025");

            // Act

            // Assert
            Assert.False(address1.Equals(address2));
        }
    }
}
