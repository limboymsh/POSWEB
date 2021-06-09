﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class SalesReturn
    {
        public Guid? Id { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? MemberId { get; set; }
        public byte? Status { get; set; }
        public string Note { get; set; }
        public decimal? TotalProce { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}
