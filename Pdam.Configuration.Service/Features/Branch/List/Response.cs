using System.Collections.Generic;
using Pdam.Common.Shared.Http;

namespace Pdam.Configuration.Service.Features.Branch.List
{
    public class Response : BaseResponse
    {
        public IEnumerable<Get.Response> Branches { get; set; }
    }
}