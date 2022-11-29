using AutoMapper;
using Core.App.DTO;
using Domain.Entities.BitFinex;
using Domain.Entities.BitStamp;

namespace Core.App.Mappings
{
    internal class HistoryPricesProfileMapping : Profile
    {
        string nameSourceBS = Enum.GetName(Domain.Enums.SourcesEn.BitStamp) ?? string.Empty;
        string nameSourceBF = Enum.GetName(Domain.Enums.SourcesEn.BitFinex) ?? string.Empty;
        public HistoryPricesProfileMapping()
        {

            CreateMap<TbBitStamp, HistoryPrices>()
              .ForMember(dest => dest.bid, opt => opt.MapFrom(src => src.bid.ToString("0.00")))
              .ForMember(dest => dest.ask, opt => opt.MapFrom(src => src.ask.ToString("0.00")))
              .ForMember(dest => dest.high, opt => opt.MapFrom(src => src.high.ToString("0.00")))
              .ForMember(dest => dest.low, opt => opt.MapFrom(src => src.low.ToString("0.00"))).AfterMap((src, dest) =>
              {
                  dest.SourcesName = nameSourceBS;
              });

            CreateMap<TbBitFinex, HistoryPrices>()
            .ForMember(dest => dest.bid, opt => opt.MapFrom(src => src.bid.ToString("0.00")))
            .ForMember(dest => dest.ask, opt => opt.MapFrom(src => src.ask.ToString("0.00")))
            .ForMember(dest => dest.high, opt => opt.MapFrom(src => src.high.ToString("0.00")))
            .ForMember(dest => dest.low, opt => opt.MapFrom(src => src.low.ToString("0.00"))).AfterMap((src, dest) =>
            {
                dest.SourcesName = nameSourceBF;
            });

        }
    }
}
