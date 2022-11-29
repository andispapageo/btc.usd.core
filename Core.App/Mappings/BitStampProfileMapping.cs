using AutoMapper;
using Core.App.ApiModels.BitStamp;
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

        }
    }
}
