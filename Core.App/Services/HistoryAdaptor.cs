using AutoMapper;
using Core.App.DTO;
using Domain.Entities.BitFinex;
using Domain.Entities.BitStamp;
namespace Core.App.Services
{
    public class HistoryAdaptor
    {
        public HistoryAdaptor(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<IEnumerable<HistoryPrices>> Merge(IEnumerable<TbBitStamp> allBitStamp, IEnumerable<TbBitFinex> allBitFinex, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var historyMain = new List<HistoryPrices>();
                foreach (var bS in allBitStamp) historyMain.Add(Mapper.Map<TbBitStamp, HistoryPrices>(bS));
                foreach (var bF in allBitFinex) historyMain.Add(Mapper.Map<TbBitFinex, HistoryPrices>(bF));
                return historyMain;
            }, cancellationToken);
        }
    }
}
