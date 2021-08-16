using System;
using System.ComponentModel.DataAnnotations;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.DataContext
{
    public class Branch
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyCode { get; set; }
        public ActiveState Status { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string BranchHeadName { get; set; }
        public Company Company { get; set; }
    }
}