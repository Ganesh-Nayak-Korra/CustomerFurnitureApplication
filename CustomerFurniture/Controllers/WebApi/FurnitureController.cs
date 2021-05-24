using CustomerFurnitureApplication.Models;
using CustomerFurnitureApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        IFurnitureRepo repo = new FurnitureRepo();
        [HttpGet]
        public IEnumerable<Furniture> GetAllFurniture()
        {
            return repo.GellAllFurniture();
        }

        [HttpPut("Title/{Title}")]
        public IActionResult Put(string title, [FromBody] Furniture furniture)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not A valid model");
            string str;
            if (furniture != null)
            {
                str = repo.Update(title, furniture);
            }
            else
            {
                return NotFound();
            }
            return Ok(str);
        }
    }
}
