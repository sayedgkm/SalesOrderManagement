using AutoMapper;
using SalesOrderManagement.Core.Domain;
using SalesOrderManagement.Core.Utilities;
using SalesOrderManagement.Shared;

namespace SalesOrderManagement.Server.Infrastructure.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<SalesOrderDTO, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SalesOrderID)).ReverseMap();
           this.CreateMap<WindowDTO, Window>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.WindowId)).ReverseMap();
            this.CreateMap<SubElementDTO, SubElement>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubElementId)).ReverseMap();

            this.CreateMap<ResponseStatusCodeDTO, ResponseStatusCodeDTO>().ReverseMap();
            this.CreateMap(typeof(ActionResultDTO<>), typeof(FunctionResult<>)).ReverseMap();


        }
    }
}
