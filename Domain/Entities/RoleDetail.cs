using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class RoleDetail
    {
        public Guid RoleId { get; set; }
        public Guid? RoleModuleId { get; set; }
        public bool? AllowCreate { get; set; }
        public bool? AllowRead { get; set; }
        public bool? AllowUpdate { get; set; }
        public bool? AllowDelete { get; set; }
    }
}
