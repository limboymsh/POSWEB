using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class TransactionDetailPromo
    {
        public Guid Id { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? TransactionDetailId { get; set; }
        public Guid? PromoId { get; set; }
        public decimal? Value { get; set; }
        public bool? IsPecentage { get; set; }
        public decimal? Total { get; set; }
    }
}
