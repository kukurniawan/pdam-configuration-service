using MediatR;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.Features.Branch.Add
{
    public class Request : IRequest<Response>
    {
        public string CompanyCode { get; set; }
        public ActiveState Status { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string BranchHeadName { get; set; }
    }
}