using AutoMapper;
using Core.App.ApiModels.BitFinex;
using Core.App.ApiModels.BitStamp;
using Core.App.DTO.BitFinex;
using Core.App.DTO.BitStamp;
using Domain.Entities.BitStamp;

namespace Core.Mapping
{
    public class BitStampProfileMapping : Profile
    {
        public BitStampProfileMapping()
        {
            CreateMap<BitStampModel, TbBitStamp>()
               .ForMember(dest => dest.timestamp, opt => opt.MapFrom(src => src.timestamp));

            CreateMap<TbBitStamp, BitStampModel>()
              .ForMember(dest => dest.timestamp, opt => opt.MapFrom(src => src.timestamp));

            CreateMap<BitStampModel, BitStampDTO>()
              .ForMember(dest => dest.bid, opt => opt.MapFrom(src => src.bid.ToString("0.00")))
              .ForMember(dest => dest.ask, opt => opt.MapFrom(src => src.ask.ToString("0.00")))
              .ForMember(dest => dest.high, opt => opt.MapFrom(src => src.high.ToString("0.00")))
              .ForMember(dest => dest.last, opt => opt.MapFrom(src => src.last.ToString("0.00")))
              .ForMember(dest => dest.vwap, opt => opt.MapFrom(src => src.vwap.ToString("0.00")))
              .ForMember(dest => dest.open, opt => opt.MapFrom(src => src.open.ToString("0.00")))
              .ForMember(dest => dest.close, opt => opt.MapFrom(src => src.close.ToString("0.00")))
              .ForMember(dest => dest.low, opt => opt.MapFrom(src => src.low.ToString("0.00")));

        }
    }
}
