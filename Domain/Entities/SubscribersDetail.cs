using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class SubscribersDetail
    {
        public Guid Id { get; set; }
        public Guid? SubscribeId { get; set; }
        public bool? IsPromo { get; set; }
        public int? Amount { get; set; }
        public bool? IsDeduction { get; set; }
        public bool? IsTax { get; set; }
        public byte? Status { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
