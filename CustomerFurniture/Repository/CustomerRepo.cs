using CustomerFurnitureApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Repository
{
    public class CustomerRepo : IcustomerRepo
    {
        CustomerFurnitureContext context = new CustomerFurnitureContext();
        public void AddCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            
        }
        public List<CustomerModel> GetAllCustomers()
        {
            var customers = context.Customers.ToList();
            //this will store the list of furniture id's got from the CustomerFurniture table
            
            List<CustomerModel> models = new List<CustomerModel>();
            foreach(var item in customers)
            {
                CustomerModel model = new CustomerModel();
                model.CustomerId = item.CustomerId;
                model.Name = item.Name;
                model.PhoneNumber = item.PhoneNumber;
                model.Address = item.Address;
                List<int> FL = new List<int>();
                List<string> furniture = new List<string>();
                var CF = context.CustomerFurnitures.Where(x => x.CustomerId == item.CustomerId);
                foreach (var s in CF)
                {
                    FL.Add((int)s.FurnitureId);
                }
                foreach (var cf in FL)
                {
                    var furni = context.Furnitures.FirstOrDefault(x => x.FurnitureId == cf);
                    furniture.Add(furni.Title);
                }
                model.LFurnitures = furniture;
                models.Add(model);
            }
            return models;
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = context.Customers.SingleOrDefault(x => x.CustomerId == id);
            if(customer==null)
            {
                return null;
            }
            return customer;
            throw new NotImplementedException();
        }
    }
}
