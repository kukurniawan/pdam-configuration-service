using AutoMapper;

namespace Pdam.Configuration.Service.Infrastructures
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<DataContext.Branch, Features.Branch.Get.Response>();
            CreateMap<Features.Branch.Add.Request, DataContext.Branch>();
            CreateMap<Features.Branch.Update.Request, DataContext.Branch>()
                .ForMember(d=>d.Status, o => o.MapFrom(s=>s.Status));
        }
    }
}