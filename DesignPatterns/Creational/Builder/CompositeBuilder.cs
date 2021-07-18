using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder
{
    /// <summary>
    /// Multiple builders will build up an object piece by piece.
    /// </summary>
    public class Person
    {
        // Address Information
        public string StreetAddress, PostCode, City;
        // Employment Information
        public string CompanyName, Position;
        public int AnnualIncome;
        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder
    {
        // the object we're going to build
        protected Person person;
        public PersonBuilder() => person = new Person();
        protected PersonBuilder(Person person) => this.person = person;
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public static implicit operator Person(PersonBuilder pb) => pb.person;

    }

    public class PersonJobBuilder: PersonBuilder
    {
        public PersonJobBuilder(Person person): base(person)
        {

        }
        public PersonJobBuilder AtCompany(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder WithDesignation(string position)
        {
            person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        //The constructor takes as reference the base PersonBuilder it inherits the Person from. 
        public PersonAddressBuilder(Person person) : base(person) => this.person = person;
        public PersonAddressBuilder AtStreet(string streetName)
        {
            person.StreetAddress = streetName;
            return this;
        }
        public PersonAddressBuilder WithPostCode(string PostCode)
        {
            person.PostCode = PostCode; 
            return this;
        }
        public PersonAddressBuilder InCity(string City)
        {
            person.City = City;
            return this;
        }
    }
}
