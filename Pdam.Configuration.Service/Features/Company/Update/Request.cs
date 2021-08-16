using MediatR;

namespace Pdam.Configuration.Service.Features.Company.Update
{
    public class Request : IRequest<Response>

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
        public int Subscription { get; set; }
        public int Status { get; set; }
    }
}