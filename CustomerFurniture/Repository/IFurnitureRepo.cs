using CustomerFurnitureApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFurnitureApplication.Repository
{
    public interface IFurnitureRepo
    {
        public List<Furniture> GellAllFurniture();
        public string Update(string title, Furniture furniture);
    }
}
