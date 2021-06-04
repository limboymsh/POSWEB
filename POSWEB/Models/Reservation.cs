using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebUI.Models
{
    public partial class Reservation
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Guid DiscountId { get; set; }
        public Guid OutletId { get; set; }
        public Guid? Code { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Guid PromoId { get; set; }
        public string Notes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
