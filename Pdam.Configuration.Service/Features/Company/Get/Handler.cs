using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pdam.Common.Shared.Fault;
using Pdam.Configuration.Service.DataContext;

namespace Pdam.Configuration.Service.Features.Company.Get
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ConfigContext _context;

        public Handler(ConfigContext context)
        {
            _context = context;
        }
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyCode == request.CompanyCode, cancellationToken);
            if (company == null)
                return new Response
                {
                    IsSuccessful = false,
                    StatusCode = 404,
                    Error = new ErrorDetail
                    {
                        Description = DefaultMessage.NotFound,
                        ErrorCode = "1404",
                        StatusCode = HttpStatusCode.NotFound
                    }
                };
            return new Response
            {
                Address = company.Address,
                City = company.City,
                Logo = company.Logo,
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
                CompanyWeb = company.CompanyWeb,
                FinanceHead = company.FinanceHead,
                CompanyLegalName = company.CompanyLegalName,
                PaymentEndPoint = company.PaymentEndPoint
            };
        }
    }
}