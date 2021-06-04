using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class Inventory
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid OutletId { get; set; }
        public string Name { get; set; }
        public Guid? PromoId { get; set; }
        public Guid? DiscountId { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsServices { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Guid InventoryCategoryId { get; set; }
        public InventoryCategory InventoryCategory { get; set;  }
    }
}
