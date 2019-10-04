using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Model.Model
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
        }

        public int PersonId { get; set; }
        public string Name { get; set; }        
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }

}