using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class DebtDetail
    {
        public Guid Id { get; set; }
        public Guid? DebtId { get; set; }
        public Guid? InventoryOrderDetailId { get; set; }
        public Guid? InventoryId { get; set; }
        public Guid? InventoryCategoryId { get; set; }
        public long? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Payleft { get; set; }
        public DateTime? IssueDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
