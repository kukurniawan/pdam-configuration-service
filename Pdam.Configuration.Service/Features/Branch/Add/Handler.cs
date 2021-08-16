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

namespace Pdam.Configuration.Service.Features.Branch.Add
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
            var company = await _context.Branches.FirstOrDefaultAsync(c => c.CompanyCode == request.CompanyCode && c.BranchCode == request.BranchCode, cancellationToken);
            if (company != null) 
                return new Response
                {
                    IsSuccessful = false,
                    StatusCode = 422,
                    Error = new ErrorDetail
                    {
                        Description = $"Kode cabang {request.BranchCode} sudah terdaftar",
                        ErrorCode = "1422",
                        StatusCode = HttpStatusCode.UnprocessableEntity
                    }
                };

            var entity = _mapper.Map<DataContext.Branch>(request);
            await _context.Branches.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            var response = new Response();
            response.AddLink("Get", _httpContextAccessor.GetFullLink("branch", $"{request.CompanyCode}/{request.BranchCode}"));
            return response;
        }
    }
}