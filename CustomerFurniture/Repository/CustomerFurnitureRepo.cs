using CustomerFurnitureApplication.Models;
using CustomerFurnitureApplication.MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Repository
{
    public class CustomerFurnitureRepo : ICustomerFurnitureRepo
    {
        CustomerFurnitureContext context = new CustomerFurnitureContext();
        CustomerRepo customerRepo = new CustomerRepo();
        public string Delete(int id)
        {
            List<Models.CustomerFurniture> customerFurniture = context.CustomerFurnitures.ToList();
            foreach (var v in customerFurniture)
            {
                if (v.CustomerId == id)
                {
                    context.CustomerFurnitures.Remove(v);
                }
            }
            context.SaveChanges();
            return "Deleted Sucessfully";
        }
    }
}
