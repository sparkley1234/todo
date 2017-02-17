using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIMinimalwithDB.Entities;

namespace WebAPIMinimalwithDB.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository()
        {

        }

        

        public Person Add(Person person)
        {

            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            PersonContext ctx = new PersonContext();
            ctx.Person.Add(person);
            ctx.SaveChanges();
            return person;
        }

        public Person Get(int Id)
        {
            PersonContext ctx = new PersonContext();
            return ctx.Person.Where(b => b.Id == Id)
                    .FirstOrDefault();
        }

        public IEnumerable<Person> GetAll()
        {
            PersonContext ctx = new PersonContext();
            return ctx.Person.ToList();
        }

        public void Remove(int Id)
        {
            PersonContext ctx = new PersonContext();
            var person =
             ctx.Person.Where(x => x.Id == Id).SingleOrDefault();
            if (person != null)
            {
                ctx.Person.Remove(person);
                ctx.SaveChanges();
            }
        }

        public bool Update(Person person)
        {
            PersonContext ctx = new PersonContext();
            Person prs = ctx.Person.Where(
              x => x.Id == person.Id).SingleOrDefault();
            if (prs != null)
            {
                ctx.Entry(prs).CurrentValues.SetValues(person);
                ctx.SaveChanges();
            }
            
            return true;
        }
    }
}