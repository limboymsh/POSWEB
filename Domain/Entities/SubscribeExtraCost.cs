using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class SubscribeExtraCost
    {
        public Guid Id { get; set; }
        public Guid? Subscribeid { get; set; }
        public Guid? SubscribeDetailId { get; set; }
        public Guid? TaxId { get; set; }
        public decimal? Value { get; set; }
        public string Percentage { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedOn { get; set; }
        public DateTime? UpdatedBy { get; set; }
    }
}
