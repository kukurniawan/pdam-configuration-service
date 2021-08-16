using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pdam.Common.Shared.Fault;
using Pdam.Configuration.Service.DataContext;

namespace Pdam.Configuration.Service.Features.Branch.Get
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ConfigContext _context;
        private readonly IMapper _mapper;

        public Handler(ConfigContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            return _mapper.Map<Response>(branch);
        }
    }
}