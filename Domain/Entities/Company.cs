using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Domain.Entities
{
    public partial class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int ProviceId { get; set; }
        public int DistrictId { get; set; }
        public bool IsSubscribe { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
