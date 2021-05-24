using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerFurnitureApplication;
using CustomerFurnitureApplication.Models;

namespace CustomerFurnitureApplication.Repository
{
    public interface ICustomerFurnitureRepo
    {
        public string Delete(int id);
    }
}
