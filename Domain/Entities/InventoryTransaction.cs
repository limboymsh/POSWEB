using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class InventoryTransaction
    {
        public Guid Id { get; set; }
        public Guid? InventoryId { get; set; }
        public Guid? InventoryCategoryId { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? InventorySourceDetailId { get; set; }
        public Guid? Quantity { get; set; }
        public Guid? TransactionDetailId { get; set; }
        public bool? IsSales { get; set; }
        public bool? IsPurchase { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
