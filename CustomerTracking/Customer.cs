using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking
{
    class Customer
    {
        public int ID { get; set; }
        public string Identity { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRegistration { get; set; }

        public Customer(string identity, string name, DateTime dateOfRegistration)
        {
            Identity = identity;
            Name = name;
            DateOfRegistration = dateOfRegistration;
        }
    }
}
