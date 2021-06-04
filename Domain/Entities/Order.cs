using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public byte? OrderTypeId { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? ReservationId { get; set; }
        public Guid? OtherTransactionId { get; set; }
        public Guid? TableId { get; set; }
        public Guid? MemberId { get; set; }
        public byte? PaymentStatus { get; set; }
        public byte? Status { get; set; }
        public Guid? Code { get; set; }
        public decimal? Price { get; set; }
        public bool? IsDeduction { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public IList<OrderDetail> OrderDetail { get; set; }
        public virtual IList<OrderTable> OrderTable { get; set; }
        public virtual OrderDeduction OrderDeduction{ get; set; }

    }
}
