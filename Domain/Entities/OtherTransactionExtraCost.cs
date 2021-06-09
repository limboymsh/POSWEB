using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class OtherTransactionExtraCost
    {
        public Guid Id { get; set; }
        public Guid? OtherTransactionId { get; set; }
        public Guid? TaxId { get; set; }
        public decimal? Value { get; set; }
        public bool? IsPercentage { get; set; }
        public decimal? Total { get; set; }
    }
}
