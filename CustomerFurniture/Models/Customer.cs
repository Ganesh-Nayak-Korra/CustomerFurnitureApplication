using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFurnitureApplication.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerFurnitures = new HashSet<CustomerFurniture>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<CustomerFurniture> CustomerFurnitures { get; set; }
    }
}
