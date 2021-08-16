using MediatR;

namespace Pdam.Configuration.Service.Features.Branch.List
{
    public class Request : IRequest<Response>
    {
        public string CompanyCode { get; set; }
    }
}