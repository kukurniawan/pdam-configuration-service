using System;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.Features.CustomerGroup
{
    public class Request
    {
        public Guid Id { get; set; }
        public string CompanyCode { get; set; }
        public ActiveState Status { get; set; }
        public string CustomerGroupCode { get; set; }
        public string CustomerGroupName { get; set; }
    }
}