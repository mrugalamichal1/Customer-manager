using Customer_Manager_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Cache;

namespace Customer_Manager_REST.Services
{
    public class CustomerRepository
    {

        private const string CacheKey = "CustomerStore";

        public CustomerRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var Customers = new Customer[]
                    {

                        new Customer
                        {
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            PhoneNumber = "885201205"
                        },
                        new Customer
                        {
                            FirstName = "Anna",
                            LastName = "Nowak",
                            PhoneNumber = "248321576"
                        },
                        new Customer
                        {
                            FirstName = "Adam",
                            LastName = "Kowalski",
                            PhoneNumber = "887423146"
                        },


                        /*new Customer("Jan","Kowalski","885201205"),
                        new Customer("Anna","Nowak","248321576"),
                        new Customer("Adam","Kowalski","887423146")*/
                    };

                    ctx.Cache[CacheKey] = Customers;
                }
            }


        }

        //Get list of all customers
        public Customer[] GetAllCustomers()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Customer[])ctx.Cache[CacheKey];
            }

            return new Customer[]
                {
                    new Customer
                    {
                        FirstName = "PLACEHOLDER",
                        LastName = "PLACEHOLDER",
                        PhoneNumber = "0000"
                    }
                };
        }


        public bool SaveCustomer(Customer Customer)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Customer[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(Customer);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }


}

