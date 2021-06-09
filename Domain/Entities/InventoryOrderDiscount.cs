using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class InventoryOrderDiscount
    {
        public Guid InventoryOrderDiscount1 { get; set; }
        public Guid? Id { get; set; }
        public Guid? InventoryOrderId { get; set; }
        public Guid? InventoryOrderDetailId { get; set; }
        public Guid? SupplierDiscountId { get; set; }
        public decimal? Value { get; set; }
        public bool? IsPercentage { get; set; }
        public decimal? Total { get; set; }
    }
}
