using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class Redeem
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? MemberId { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? RedeemTypeId { get; set; }
        public decimal? RedeemValue { get; set; }
        public decimal? EarnValue { get; set; }
        public DateTime? IssueDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
