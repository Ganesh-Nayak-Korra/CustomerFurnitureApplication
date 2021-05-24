using CustomerFurnitureApplication.Models;
using CustomerFurnitureApplication.MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Repository
{
    public class FurnitureRepo : IFurnitureRepo
    {
        CustomerFurnitureContext context = new CustomerFurnitureContext();
        public List<Furniture> GellAllFurniture()
        {
            return context.Furnitures.ToList();
        }

        public string Update(string title,Furniture furniture)
        {
            var existingAgent = context.Furnitures.First(x => x.Title.Equals(furniture.Title));
            try
            {
                if (existingAgent != null)
                {
                    existingAgent.Price = furniture.Price;
                    context.SaveChanges();
                    return "updated Sucessfully";
                }
                else
                throw new CustomException("Not found");
            }
            catch (CustomException ex)
            {
                return ex.ToString();

            }
            throw new NotImplementedException();
        }
    }
}
