using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFurnitureApplication.Models
{
    public partial class Furniture
    {
        public Furniture()
        {
            CustomerFurnitures = new HashSet<CustomerFurniture>();
        }

        public int FurnitureId { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<CustomerFurniture> CustomerFurnitures { get; set; }
    }
}
