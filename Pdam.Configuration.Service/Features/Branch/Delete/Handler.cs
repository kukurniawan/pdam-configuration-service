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

namespace Pdam.Configuration.Service.Features.Branch.Delete
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
            var branch = await _context.Branches.FirstOrDefaultAsync(x => x.CompanyCode == request.CompanyCode && x.BranchCode == request.BranchCode, cancellationToken);
            if (branch == null)
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
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync(cancellationToken);
            var response = new Response();
            response.AddLink("Get", _httpContextAccessor.GetFullLink("branch", $"{request.CompanyCode}/{request.BranchCode}"));
            return response;
        }
    }
}