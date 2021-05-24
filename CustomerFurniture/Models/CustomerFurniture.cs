using System;
using System.Collections.Generic;

#nullable disable

namespace CustomerFurnitureApplication.Models
{
    public partial class CustomerFurniture
    {
        public int Cfid { get; set; }
        public int? CustomerId { get; set; }
        public int? FurnitureId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Furniture Furniture { get; set; }
    }
}
