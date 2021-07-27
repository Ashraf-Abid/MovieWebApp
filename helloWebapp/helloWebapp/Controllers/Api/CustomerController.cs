using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using helloWebapp.Models;

namespace helloWebapp.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController(){
            _context = new ApplicationDbContext();
        }
        //GET/api/customers
        public IEnumerable<Customer> GetCustomers() {
            return _context.customers.ToList() ;
        }
        //Get/api/customers/1
        [HttpGet]
        [ActionName("GetCustomerById")]
        public HttpResponseMessage GetCustomerById(int id) {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
            }

        }
        [HttpGet]
        [ActionName("GetAllCustomers")]
        public HttpResponseMessage GetAllCustomers()
        {
            var customers = _context.customers.ToList();
            if (customers != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
            }

        }
        //post/api/customer
        [HttpPost]
        public HttpResponseMessage CreateCustomer(Customer customer) {

            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.customers.Add(customer);
            _context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, customer); 


        }
        //put/api/customer/1
        [HttpPut]
        [ActionName("UpdateCustomer")]
        public HttpResponseMessage UpdateCustomer(Customer customer) {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == customer.Id);
            if (customerInDb != null) {
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "SuccessFully Updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Customer Id Not found");
            }


        }

        [HttpPut]
        [ActionName("SSSCustomer")]
        public HttpResponseMessage SSSCustomer(Customer customer)
        {
            if (!ModelState.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == customer.Id);
            if (customerInDb != null)
            {
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "SuccessFully Updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Customer Id Not found");
            }


        }
        //Delet/api/Customer/1;
        [HttpDelete]
        public void DeleteCustomer(int id) {
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
