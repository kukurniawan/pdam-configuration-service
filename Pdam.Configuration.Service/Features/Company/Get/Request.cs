using MediatR;

namespace Pdam.Configuration.Service.Features.Company.Get
{
    public class Request : IRequest<Response>
    {
        public string CompanyCode { get; set; }
    }
}