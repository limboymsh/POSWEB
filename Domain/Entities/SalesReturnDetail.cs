using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class SalesReturnDetail
    {
        public Guid Id { get; set; }
        public Guid? SalesReturnId { get; set; }
        public Guid? TransactionDetailId { get; set; }
        public Guid? OrderDetailId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? SalesReturnCategoryId { get; set; }
        public byte? Status { get; set; }
        public string Note { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
