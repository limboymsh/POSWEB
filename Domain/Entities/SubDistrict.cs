using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class SubDistrict
    {
        public Guid SubDisctrict { get; set; }
        public Guid? DistrictId { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
    }
}
