
using AutoMapper;

namespace Pdam.Configuration.Service.Infrastructures
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<DataContext.Company, Features.Company.Get.Response>();
        }
    }
}