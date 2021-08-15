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

namespace Pdam.Configuration.Service.Features.Company.Add
{
    public class Handler : IRequestHandler<Request,Response>
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
            if (company != null) 
                return new Response
                {
                    IsSuccessful = false,
                    StatusCode = 422,
                    Error = new ErrorDetail
                    {
                        Description = $"Kode perusahaan {request.CompanyCode} sudah terdaftar",
                        ErrorCode = "1422",
                        StatusCode = HttpStatusCode.UnprocessableEntity
                    }
                };

            var entity = _mapper.Map<DataContext.Company>(request);
            await _context.Companies.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var response = new Response();
            response.AddLink("Get", _httpContextAccessor.GetFullLink("company", request.CompanyCode));
            return response;
        }
    }
}