using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.DataContext
{
    public class CustomerGroup
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyCode { get; set; }
        public ActiveState Status { get; set; }
        public string CustomerGroupCode { get; set; }
        public string CustomerGroupName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public IEnumerable<CustomerGroupPricing> CustomerGroupPricings { get; set; }
    }
}