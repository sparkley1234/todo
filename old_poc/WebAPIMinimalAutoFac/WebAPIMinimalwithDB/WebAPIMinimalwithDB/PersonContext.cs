using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIMinimalwithDB.Entities;
using WebAPIMinimalwithDB.PersonRepository;

namespace WebAPIMinimalwithDB
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("name=persondbConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}