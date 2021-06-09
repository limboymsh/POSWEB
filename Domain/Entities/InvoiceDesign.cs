using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class InvoiceDesign
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string OutletId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}
