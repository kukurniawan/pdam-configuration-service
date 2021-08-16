using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pdam.Common.Shared.Fault;
using Pdam.Common.Shared.Http;
using Pdam.Configuration.Service.DataContext;

namespace Pdam.Configuration.Service.Features.Company.Update
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ConfigContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Handler(ConfigContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyCode == request.CompanyCode, cancellationToken);
            if (company == null) 
                return new Response
                {
                    IsSuccessful = false,
                    StatusCode = 422,
                    Error = new ErrorDetail
                    {
                        Description = $"Kode perusahaan {request.CompanyCode} tidak ditemukan",
                        ErrorCode = "1422",
                        StatusCode = HttpStatusCode.UnprocessableEntity
                    }
                };

            _mapper.Map(request, company);
            await _context.SaveChangesAsync(cancellationToken);
            var response = new Response();
            response.AddLink("Get", _httpContextAccessor.GetFullLink("company", request.CompanyCode));
            return response;
        }
    }
}