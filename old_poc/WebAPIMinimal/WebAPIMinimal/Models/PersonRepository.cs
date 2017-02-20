using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMinimal.Models
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _person = new List<Person>();
        private int fakeDatabaseId = 1;

        public PersonRepository()
        {
            this.Add(new Person { FirstName = "Aqeel", LastName = "Ansari" });
            this.Add(new Person { FirstName = "Sahil", LastName = "Khan" });
            this.Add(new Person { FirstName = "Amit", LastName = "Kumar" });
        }
        public Person Add(Person person)
        {
            if(person == null)
            {
                throw new ArgumentNullException("person");
            }
            person.Id = fakeDatabaseId++;
            _person.Add(person);
            return person;
        }

        public Person Get(int Id)
        {
            return _person.Find(p => p.Id == Id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _person;
        }

        public void Remove(int Id)
        {
            _person.RemoveAll(p => p.Id == Id);
        }

        public bool Update(Person person)
        {
            if(person == null)
            {
                throw new ArgumentNullException("person");

            }
            int index = _person.FindIndex(p => p.Id == person.Id);
            if(index == -1)
            {
                return false;
            }
            _person.RemoveAt(index);
            _person.Add(person);
            return true;
        }
    }
}