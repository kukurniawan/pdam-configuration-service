using System;
using System.ComponentModel.DataAnnotations;

namespace Pdam.Configuration.Service.DataContext
{
    public class CustomerGroupPricingDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerGroupPricingId { get; set; }
        public bool IsFixedPrice { get; set; }
        public string MappingColumn { get; set; }
        public string PriceName { get; set; }
        public decimal StartUnit { get; set; }
        public decimal EndUnit { get; set; }
        public decimal SalesPrice { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public CustomerGroupPricing CustomerGroupPricing { get; set; }
    }
}