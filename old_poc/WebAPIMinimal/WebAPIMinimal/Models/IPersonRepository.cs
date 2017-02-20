using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMinimal.Models
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