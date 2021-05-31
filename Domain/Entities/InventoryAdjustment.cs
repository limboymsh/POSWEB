using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class InventoryAdjustment
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid OutletId { get; set; }
        public Guid InventoryId { get; set; }
        public Guid InventoryCategoryId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public byte IsReduce { get; set; }
        public byte IsIncrease { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
