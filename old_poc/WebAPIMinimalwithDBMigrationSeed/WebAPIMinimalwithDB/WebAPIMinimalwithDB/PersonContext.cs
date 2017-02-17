using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPIMinimalwithDB.Models;

namespace WebAPIMinimalwithDB
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("name=persondbConnection")
        {

        }
        public DbSet<Person> Person { get; set; }
    }
}