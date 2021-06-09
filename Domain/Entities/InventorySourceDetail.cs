using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class InventorySourceDetail
    {
        public Guid Id { get; set; }
        public Guid? InventorySourceId { get; set; }
        public Guid? InventoryId { get; set; }
        public Guid? InventoryCategoryid { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? InventoryOrderDetailId { get; set; }
        public Guid? SupplierId { get; set; }
        public long? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedeOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
