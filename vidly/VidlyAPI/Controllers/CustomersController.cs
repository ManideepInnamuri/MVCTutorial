using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAPI.Models;

namespace VidlyAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api/Customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList());
        }

        // Get /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(customer);
        }

        //Post / api/Customers
        [HttpPost]
        public IHttpActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        //Put /api/Customers
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerinDb = _context.Customers.SingleOrDefault(p => p.Id == id);
            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerinDb.Name = customer.Name;
            customerinDb.DateofBirth = customer.DateofBirth;
            customerinDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerinDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
            return Ok(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(p => p.Id == id);
            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerinDb);
            _context.SaveChanges();
            return Ok(HttpStatusCode.NoContent);
        }
    }
}
