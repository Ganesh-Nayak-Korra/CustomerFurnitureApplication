using CustomerFurnitureApplication.Models;
using CustomerFurnitureApplication.MyException;
using CustomerFurnitureApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IcustomerRepo repo = new CustomerRepo();
        [HttpGet]
        public IEnumerable<CustomerModel> GetAll()
        {
            List<CustomerModel> customers = repo.GetAllCustomers();
            return customers;
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            Customer customer = repo.GetCustomer(id);
            return customer;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                repo.AddCustomer(customer);
                return Ok("posted successfully");
                throw new CustomException("Not Added to Database");
            }
            catch (CustomException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
