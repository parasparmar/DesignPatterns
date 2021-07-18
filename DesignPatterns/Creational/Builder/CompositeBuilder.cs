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
    }

    public class PersonBuilder
    {
        protected Person person;

        public PersonBuilder() => person = new Person();
        protected PersonBuilder(Person person) => this.person = person;
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public static implicit operator Person(PersonBuilder pb) => pb.person;

    }

    public class PersonJobBuilder
    {
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person) : base(person) => this.person = person;


    }
}
