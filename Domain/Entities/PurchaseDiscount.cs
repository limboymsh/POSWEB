using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class PurchaseDiscount
    {
        public Guid Id { get; set; }
        public Guid? PurchaseId { get; set; }
        public Guid? DiscountId { get; set; }
        public decimal? Value { get; set; }
        public bool? IsPercentage { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
