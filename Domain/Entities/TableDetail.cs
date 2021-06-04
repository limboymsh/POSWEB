using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class TableDetail
    {
        public Guid Id { get; set; }
        public Guid? TableId { get; set; }
        public byte? Status { get; set; }
        public int? ChairNumbers { get; set; }

        public virtual Table Table { get; set; }
    }
}
