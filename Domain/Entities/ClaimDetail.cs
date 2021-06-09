using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class ClaimDetail
    {
        public Guid Id { get; set; }
        public Guid? ClaimId { get; set; }
        public Guid? InventoryId { get; set; }
        public Guid? InventoryCategoryId { get; set; }
        public Guid? OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Paid { get; set; }
        public decimal? PayLeft { get; set; }
        public string IssueDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}
