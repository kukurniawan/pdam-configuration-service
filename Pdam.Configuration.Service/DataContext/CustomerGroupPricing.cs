using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.DataContext
{
    public class CustomerGroupPricing
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerGroupId { get; set; }
        public Guid ProductId { get; set; }
        public string PriceName { get; set; }
        public DateTime StartActive { get; set; }
        public DateTime EndActive { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Product Product { get; set; }
        public CustomerGroup CustomerGroup { get; set; }
        public IEnumerable<CustomerGroupPricingDetail> CustomerGroupPricingDetails { get; set; }
    }
}