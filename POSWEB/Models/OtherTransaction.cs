using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebUI.Models
{
    public partial class OtherTransaction
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? OtherTransactionTypeId { get; set; }
        public Guid? MemberId { get; set; }
        public string Code { get; set; }
        public byte? Status { get; set; }
        public DateTime? IssueDate { get; set; }
        public decimal? Total { get; set; }
        public decimal? SubTotal { get; set; }
        public string Notes { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
