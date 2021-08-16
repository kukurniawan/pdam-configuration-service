using MediatR;

namespace Pdam.Configuration.Service.Features.Branch.Get
{
    public class Request : IRequest<Response>
    {
        public string BranchCode { get; set; }
        public string CompanyCode { get; set; }
    }
}