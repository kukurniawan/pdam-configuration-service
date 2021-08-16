using System;
using Pdam.Common.Shared.Http;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.Features.Branch.Get
{
    public class Response : BaseResponse
    {
        public Guid Id { get; set; }
        public string CompanyCode { get; set; }
        public ActiveState Status { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string BranchHeadName { get; set; }
    }
}