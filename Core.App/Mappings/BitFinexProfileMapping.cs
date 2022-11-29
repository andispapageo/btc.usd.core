using AutoMapper;
using Core.App.ApiModels.BitFinex;
using Core.App.DTO.BitFinex;
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

            CreateMap<BitFinexModel, BitFinexDTO>()
                .ForMember(dest => dest.bid, opt => opt.MapFrom(src => src.bid.ToString("0.00")))
                .ForMember(dest => dest.ask, opt => opt.MapFrom(src => src.ask.ToString("0.00")))
                .ForMember(dest => dest.high, opt => opt.MapFrom(src => src.high.ToString("0.00")))
                .ForMember(dest => dest.last_price, opt => opt.MapFrom(src => src.last_price.ToString("0.00")))
                .ForMember(dest => dest.low, opt => opt.MapFrom(src => src.low.ToString("0.00")))
                .ForMember(dest => dest.mid, opt => opt.MapFrom(src => src.mid.ToString("0.00")));
        }
    }
}
