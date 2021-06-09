using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class PromoProductCategory
    {
        public Guid PromoDetailId { get; set; }
        public Guid? InventoryCategoryId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsRequired { get; set; }
    }
}
