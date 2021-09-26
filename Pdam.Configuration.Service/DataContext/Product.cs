using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.DataContext
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string MarketName { get; set; }
        public string Uom { get; set; }
        public string MethodValuating { get; set; }
        public string PricingMethod { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Company Company { get; set; }
        public IEnumerable<CustomerGroupPricing> CustomerGroupPricings { get; set; }
    }
}