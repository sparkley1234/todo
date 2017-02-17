using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebAPIMinimalwithDB.PersonRepository;

namespace WebAPIMinimalwithDB.Entities
{
    public class PersonMapper : EntityTypeConfiguration<Person>
    {
        public PersonMapper()
        {
            this.ToTable("People");

            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(c => c.FirstName).IsRequired();
            this.Property(c => c.FirstName).HasMaxLength(50);

            this.Property(c => c.LastName).IsRequired();
            this.Property(c => c.LastName).HasMaxLength(50);

            this.Property(c => c.Gender).IsRequired();

            this.Property(c => c.Mobile).IsRequired();
            this.Property(c => c.Mobile).HasMaxLength(10);

            this.Property(c => c.Email).IsRequired();
            this.Property(c => c.Email).HasMaxLength(60);


        }
    }
}