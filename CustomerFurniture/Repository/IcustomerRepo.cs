using CustomerFurnitureApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Repository
{
    public interface IcustomerRepo
    {
        public Customer GetCustomer(int id);
        public void AddCustomer(Customer customer);
        List<CustomerModel> GetAllCustomers();
    }
}
