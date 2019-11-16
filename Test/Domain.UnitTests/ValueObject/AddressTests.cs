using System;
using System.Diagnostics;
using Company.Project.Domain.Exceptions;
using Company.Project.Domain.ValueObjects;
using Xunit;

namespace Company.Project.Domain.UnitTests.ValueObject
{
    public class AddressTests
    {
        [Fact]
        public void Given_valid_string_returns_address_object()
        {
            // Arrange
            var stringAddress = "Calle Balmes 123, Barcelona, Cataluña, España, 08025";

            // Act
            var addressObject = (Address)stringAddress;

            // Assert
            Assert.IsType<Address>(addressObject);
        }

        [Fact]
        public void Given_valid_string_returns_well_form_address_object()
        {
            // Arrange
            var street = "Calle Balmes 123";
            var city = "Barcelona";
            var province = "Cataluña";
            var country = "España";
            var zipCode = "08025";
            var comma = ",";
            var stringAddress = string.Concat(street, comma, city, comma, province, comma, country, comma, zipCode);

            // Act
            var addressObject = (Address)stringAddress;

            // Assert
            Assert.Equal(street, addressObject.Street);
            Assert.Equal(city, addressObject.City);
            Assert.Equal(province, addressObject.State);
            Assert.Equal(country, addressObject.Country);
            Assert.Equal(zipCode, addressObject.ZipCode);
        }

        [Fact]
        public void Given_invalid_string_throws_exceptions()
        {
            // Arrange
            var street = "Calle Balmes 123";
            var city = "Barcelona";
            var province = "Cataluña";
            var country = "España";
            var zipCode = "08025";
            var comma = ",";
            var stringAddress = string.Concat(street, comma, city, comma, province, comma, zipCode, comma, country);

            // Act
            Assert.Throws<InvalidAddressString>(() => { var addressObject = (Address)stringAddress; });

            // Assert


        }
    }
}
