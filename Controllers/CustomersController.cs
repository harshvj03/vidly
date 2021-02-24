using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        DatabaseContext db = new DatabaseContext();
        public ViewResult Index()
        {
            //var customers = GetCustomers();

            return View(db.Customer.Include(c => c.memberShipType).ToList());
        }

        public ActionResult New()
        {
            var memberShipType = db.MemberShipType.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                memberShipTypes = memberShipType
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                memberShipTypes = db.MemberShipType.ToList()

            };
            return View("New", viewModel);
            
        }


        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    memberShipTypes = db.MemberShipType.ToList()
                };
                return View("New",viewModel);
            }

            if(customer.Id == 0)
                db.Customer.Add(customer);
            else
            {
                var custInDb = db.Customer.Single(c => c.Id == customer.Id);

                custInDb.Name = customer.Name;
                custInDb.Birthdate = customer.Birthdate;
                custInDb.memberShipTypeId = customer.memberShipTypeId;
                custInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Details(int id)
        {
            var customer = db.Customer.Include(c => c.memberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}