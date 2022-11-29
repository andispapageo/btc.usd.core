using AutoMapper;
using Core.App.ApiModels.BitFinex;
using Domain.Entities.BitFinex;

namespace Core.Mapping
{
    public class BitFinexProfileMapping : Profile
    {
        public BitFinexProfileMapping() {

            CreateProjection<BitFinexModel, TbBitFinex>()
                .ForMember(dest => dest.timestamp, opt => opt.MapFrom(src => src.timestamp));

            CreateMap<BitFinexModel, TbBitFinex>()
               .ForMember(dest => dest.timestamp, opt => opt.MapFrom(src => src.timestamp));

            CreateMap<TbBitFinex, BitFinexModel>()
              .ForMember(dest => dest.timestamp, opt => opt.MapFrom(src => src.timestamp));
        }
    }
}
