using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIMinimalwithDB.Enums;

namespace WebAPIMinimalwithDB.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

    }
}