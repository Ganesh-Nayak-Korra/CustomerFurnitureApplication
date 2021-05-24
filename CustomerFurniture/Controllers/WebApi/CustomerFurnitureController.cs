using CustomerFurnitureApplication.Models;
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
    public class CustomerFurnitureController : ControllerBase
    {
        public CustomerFurnitureRepo repo = new CustomerFurnitureRepo();
        [HttpDelete("CustomerId/{id}")]
        public string Delete(int id)
        {
            string str =repo.Delete(id);
            return str;
        }
    }
}