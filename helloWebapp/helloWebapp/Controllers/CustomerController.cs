using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloWebapp.Models;
using helloWebapp.ViewModels;
using System.Data.Entity;

namespace helloWebapp.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Edit(int id) {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) return HttpNotFound();
            var viewModel = new CustomerformViewModel {
                Customer = customer,
                MembershipTypes = _context.membershiptypes.ToList()
        };
            return View("CustomerForm",viewModel);
        }
        public ActionResult New() {
            var membershipTypes = _context.membershiptypes.ToList();
            var vewmodel = new CustomerformViewModel
            {
                MembershipTypes = membershipTypes,
  

            };

             
            return View("CustomerForm",vewmodel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer) {
            if (!ModelState.IsValid) {
                var viewModel = new CustomerformViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.membershiptypes.ToList()
                };
                return View("CustomerForm",viewModel);
            
            }
            if (customer.Id == 0)
            {
                _context.customers.Add(customer);
            }
            else {
                var customerInDb = _context.customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;

                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;


            }
            _context.SaveChanges();


            return RedirectToAction("Index","Customer");
        }
        public ViewResult Index() {
            var customers = _context.customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
      /*  private IEnumerable<Customer> getCustomer() {
            return new List<Customer>{
            new Customer {Name="PAGOL",Id=1},
            new Customer {Name="SAGOL",Id=2}
            };
        }*/
        

        // GET: Customer
        //Code by me
         /*public ActionResult CustomerHandle()
         {

             var customers = new List<Models.Customer>
             {
                new Models.Customer{ Name="Customer1"},
                 new Models.Customer{ Name="Customer2"}
             };
             var viewModel = new CustomerViewModel
             {
                 Customers = customers
             };
             return View(viewModel);
         }*/
        


    }
}