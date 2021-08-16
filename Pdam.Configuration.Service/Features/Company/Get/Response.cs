using Pdam.Common.Shared.Http;
using Pdam.Common.Shared.State;

namespace Pdam.Configuration.Service.Features.Company.Get
{
    public class Response : BaseResponse
    {
        public string CompanyCode { get; set; }
        public string CompanyLegalName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CompanyWeb { get; set; }
        public string PaymentEndPoint { get; set; }
        public string Logo { get; set; }
        public string FinanceHead { get; set; }
        public string DirectorName { get; set; }
        public SubscriptionState Subscription { get; set; }
        public ActiveState Status { get; set; }
    }
}