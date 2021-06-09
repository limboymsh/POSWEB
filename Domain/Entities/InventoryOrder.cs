﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class InventoryOrder
    {
        public Guid Id { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? OutletId { get; set; }
        public Guid? SupplierId { get; set; }
        public string Code { get; set; }
        public byte? PaymentStatus { get; set; }
        public decimal? Total { get; set; }
        public decimal? GeneralTotal { get; set; }
        public string Notes { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
