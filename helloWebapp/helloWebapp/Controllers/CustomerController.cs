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
        public ActionResult New() {
            var membershipTypes = _context.membershiptypes.ToList();
            var vewmodel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes,
  

            };

             
            return View(vewmodel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer) {
            _context.customers.Add(customer);
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