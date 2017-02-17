namespace WebAPIMinimalwithDB.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIMinimalwithDB.PersonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PersonContext context)
        {
            var person = new List<Person>
            {
            new Person{FirstName="Ark",LastName="Roop"},
            new Person{FirstName="Akash",LastName="Gupta"},
            new Person{FirstName="Saurabh",LastName="Gupta"},
            };
            person.ForEach(s => context.Person.Add(s));
            context.SaveChanges();
        }
    }
}
