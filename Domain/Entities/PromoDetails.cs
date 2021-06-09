using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class PromoDetails
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? PromoId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? MaxUsage { get; set; }
        public decimal? MaxUsagePerDay { get; set; }
        public bool? IsRequiredInventory { get; set; }
        public bool? IsRequiredProductCategory { get; set; }
        public decimal? TransactionAmountRequired { get; set; }
        public long? TransactionCountRequired { get; set; }
        public long? PointRequired { get; set; }
        public decimal? BonusDeductionValue { get; set; }
        public decimal? BonusDeductionPercentage { get; set; }
        public decimal? MaxDeductionAmount { get; set; }
        public bool? IsSuspend { get; set; }
        public bool? IsActive { get; set; }
        public Guid? CreatedOn { get; set; }
        public DateTime? CreatedBy { get; set; }
        public Guid? UpdatedOn { get; set; }
        public DateTime? UpdatedBy { get; set; }
    }
}
