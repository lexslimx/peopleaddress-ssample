using System;
using System.Collections.Generic;

namespace ConsoleApp1.Model.Model
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string PoBox { get; set; }
        public string City { get; set; }
        public int? PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}