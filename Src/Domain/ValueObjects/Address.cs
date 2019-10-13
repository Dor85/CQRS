﻿using Company.Project.Domain.Common;
using Company.Project.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Company.Project.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public Address() { }
        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }

        public static implicit operator string(Address address)
        {
            return address.ToString();
        }
        public static explicit operator Address(string address)
        {
            return ConvertAddress(address);
        }
        public override string ToString()
        {
            return $"{Street}, {City}, {State}, {Country}, {ZipCode}";
        }
        private static Address ConvertAddress(string addressString)
        {
            Address address;
            try
            {
                var split = addressString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length < 5)
                {
                    throw new InvalidEnumArgumentException();
                }
                address = new Address(split[0].Trim(), split[1].Trim(), split[2].Trim(), split[3].Trim(), split[4].Trim());
            }
            catch (Exception ex)
            {
                throw new InvalidAddressString("The address param is not valid", ex);
            }
            return address;
        }
    }
}
