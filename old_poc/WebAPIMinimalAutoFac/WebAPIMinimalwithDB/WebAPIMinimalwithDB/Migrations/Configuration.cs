namespace WebAPIMinimalwithDB.Migrations
{
    using Entities;
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
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebAPIMinimalwithDB.PersonContext context)
        {
            var person = new List<Person>
            {
            new Person{FirstName="Ark",LastName="Roop", Gender = 0, Mobile = "9999999991", Email = "arkmno@gmail.com"},
            new Person{FirstName="Akash",LastName="Gupta", Gender = 0, Mobile = "9999999992", Email = "akashmno@gmail.com"},
            new Person{FirstName="Saurabh",LastName="Gupta", Gender = 0, Mobile = "9999999993", Email = "saurabhmno@gmail.com"},
            };
            person.ForEach(s => context.Person.Add(s));
            context.SaveChanges();
        }
    }
}
