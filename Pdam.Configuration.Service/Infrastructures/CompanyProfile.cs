
using AutoMapper;

namespace Pdam.Configuration.Service.Infrastructures
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<DataContext.Company, Features.Company.Get.Response>();
            CreateMap<Features.Company.Add.Request, DataContext.Company>()
                .ForMember(d=>d.Status, o => o.MapFrom(s=>s.Status))
                .ForMember(d=>d.Subscription, o => o.MapFrom(s=>s.Subscription));
            CreateMap<Features.Company.Update.Request, DataContext.Company>()
                .ForMember(d=>d.Status, o => o.MapFrom(s=>s.Status))
                .ForMember(d=>d.Subscription, o => o.MapFrom(s=>s.Subscription));
        }
    }
}