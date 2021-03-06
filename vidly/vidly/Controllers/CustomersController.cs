﻿using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using vidly.Models;
using Common.Models;
using Common.ViewModels;

namespace vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private MovieDBContext _context;
        public CustomersController()
        {
            _context = new MovieDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            return View("CustomerForm", new CustomerFormViewModel() { Customer = new Customer(), MembershipTypes = membershipTypes });
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.DocumentFile != null)
            {
                customer.DocumentFile.SaveAs(Server.MapPath(Path.Combine(@"~\content\Images", customer.DocumentFile.FileName)));
                customer.ImagePath = Path.Combine(@"\content\Images", customer.DocumentFile.FileName);
            }
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", new CustomerFormViewModel() { Customer = customer, MembershipTypes = _context.MembershipTypes.ToList() });
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.DateofBirth = customer.DateofBirth;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDB.ImagePath = customer.ImagePath;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View("CustomerForm", new CustomerFormViewModel() { Customer = customer, MembershipTypes = _context.MembershipTypes.ToList() });
        }
    }
}