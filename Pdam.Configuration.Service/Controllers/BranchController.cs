using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pdam.Common.Shared.Infrastructure;

namespace Pdam.Configuration.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{companyCode}/{branchCode}")]
        public async Task<IActionResult> Get([FromRoute] string companyCode, [FromRoute] string branchCode)
        {
            var response = await _mediator.Send(new Features.Branch.Get.Request
            {
                CompanyCode = companyCode,
                BranchCode = branchCode
            });
            return ActionResultMapper.ToActionResult(response);
        }
        
        [HttpGet("{companyCode}")]
        public async Task<IActionResult> Get([FromRoute] string companyCode)
        {
            var response = await _mediator.Send(new Features.Branch.List.Request
            {
                CompanyCode = companyCode
            });
            return ActionResultMapper.ToActionResult(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Features.Branch.Add.Request request)
        {
            var response = await _mediator.Send(request);
            return ActionResultMapper.ToActionResult(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Features.Branch.Update.Request request)
        {
            var response = await _mediator.Send(request);
            return ActionResultMapper.ToActionResult(response);
        }
    }
}