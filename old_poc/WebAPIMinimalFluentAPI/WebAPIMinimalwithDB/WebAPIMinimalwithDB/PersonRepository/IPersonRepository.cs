using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMinimalwithDB.Entities;

namespace WebAPIMinimalwithDB.PersonRepository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int Id);
        Person Add(Person person);
        void Remove(int Id);
        bool Update(Person person);
    }
}
