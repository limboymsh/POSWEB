using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class OrderDeduction
    {
        public Guid? Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? PromoId { get; set; }
        public Guid? DiscountId { get; set; }
        public int? Value { get; set; }
        public byte? IsPercentage { get; set; }
        public int? Total { get; set; }
    }
}
