using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIMinimalwithDB.Entities;
using WebAPIMinimalwithDB.PersonRepository;

namespace WebAPIMinimalwithDB.Controllers
{
    public class PersonController : ApiController
    {
        static readonly IPersonRepository databasePlaceholder = new PersonRepository.PersonRepository();

        public IEnumerable<Person> GetAllPeople()
        {
            return databasePlaceholder.GetAll();
        }
        public Person GetPersonByID(int Id)
        {
            Person person = databasePlaceholder.Get(Id);
            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return person;
        }

        public HttpResponseMessage PostPerson(Person person)
        {
            person = databasePlaceholder.Add(person);

            var response =
                this.Request.CreateResponse<Person>(HttpStatusCode.Created, person);
            string uri = Url.Link("Person", new { id = person.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public bool PutPerson(Person person)
        {
            if (!databasePlaceholder.Update(person))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return true;


        }
        public bool DeletePerson(int Id)
        {
            Person person = databasePlaceholder.Get(Id);
            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databasePlaceholder.Remove(Id);
            return true;
        }
    }
}
