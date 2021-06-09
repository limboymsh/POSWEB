using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class MutationDetail
    {
        public Guid Id { get; set; }
        public Guid? MutationId { get; set; }
        public Guid? ProductId { get; set; }
        public long? Qty { get; set; }
        public string Description { get; set; }
    }
}
