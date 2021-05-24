using CustomerFurnitureApplication.Models;
using CustomerFurnitureApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Controllers
{
    public class MVCCustomerController : Controller
    {
        IcustomerRepo repo = new CustomerRepo();
        public IActionResult Index()
        {
            List<CustomerModel> customers= repo.GetAllCustomers();
            return View(customers);
        }
    }
}
