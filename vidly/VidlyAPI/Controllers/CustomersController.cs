using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VidlyAPI.DTOs;
using VidlyAPI.Models;

namespace VidlyAPI.Controllers
{
    [EnableCors("*","*","*")]
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
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>));
        }

        // Get /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //Post / api/Customers
        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        //Put /api/Customers
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerinDb = _context.Customers.SingleOrDefault(p => p.Id == id);
            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerinDb);
            _context.SaveChanges();
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
