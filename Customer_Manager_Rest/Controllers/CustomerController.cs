using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Customer_Manager_REST.Models;
using Customer_Manager_REST.Services;

namespace Customer_Manager_Rest.Controllers
{
    public class CustomerController : ApiController
    {

        private CustomerRepository customerRepository;

        public CustomerController()
        {
            this.customerRepository = new CustomerRepository();
        }

        // GET: api/Customer
        public Customer[] Get()
        {
            return this.customerRepository.GetAllCustomers();
        }

        // POST: api/Customer
        public HttpResponseMessage Post(Customer customer)
        {
            this.customerRepository.SaveCustomer(customer);
            var response = Request.CreateResponse<Customer>(HttpStatusCode.Created, customer);
            return response;
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
