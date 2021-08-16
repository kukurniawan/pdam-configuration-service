using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pdam.Common.Shared.Fault;
using Pdam.Configuration.Service.DataContext;

namespace Pdam.Configuration.Service.Features.Branch.List
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
            var branches = await _context.Branches.Where(x => x.CompanyCode == request.CompanyCode).ToListAsync(cancellationToken);
            if (branches.Count == 0)
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
                Branches = branches.Select(x=> _mapper.Map<Get.Response>(x)) 
            };
        }
    }
}