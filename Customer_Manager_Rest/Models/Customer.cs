using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Manager_REST.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        //Customer constructor with parameters
        public Customer(string firstname, string lastname, string phonenumber)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PhoneNumber = phonenumber;
        }

        public Customer()
        {

        }
    }
}
