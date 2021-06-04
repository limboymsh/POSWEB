using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class TransactionExtraCost
    {
        public Guid? Id { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? TaxId { get; set; }
        public decimal? Value { get; set; }
        public bool? IsPersentage { get; set; }
        public int? Total { get; set; }
    }
}
