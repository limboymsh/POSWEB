using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public partial class OrderDeductionModel
    {
        public Guid Id { get; set; }
        public Guid? PromoId { get; set; }
        public Guid? DiscountId { get; set; }
        public int? Value { get; set; }
        public byte? IsPercentage { get; set; }
        public int? Total { get; set; }
    }
}
