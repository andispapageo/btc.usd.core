using AutoMapper;
using Core.App.ApiModels.BitFinex;
using Core.Interfaces.Interfaces.IData;
using Domain.Entities.BitFinex;

namespace Core.App.Services
{
    public class BitFinexAdaptor<TApim, TEntm> 
        where TApim : BitFinexModel 
        where TEntm : TbBitFinex
    {
        public BitFinexAdaptor(IMapper mapper, IUnitOfWork<TEntm> unitOfWorkBitFinex)
        {
            Mapper = mapper;
            UnitOfWorkBitFinex = unitOfWorkBitFinex;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork<TEntm> UnitOfWorkBitFinex { get; }

        public async Task AddModel(IEnumerable<TApim> bitFinexModels)
        {
            if (!bitFinexModels?.Any() ?? false) return;
            var mapped = Mapper.Map<TApim, TEntm>(source: bitFinexModels?.FirstOrDefault());
            await UnitOfWorkBitFinex.GetRepository().InsertOrUpdate(mapped);
        }

        public async Task<IEnumerable<TEntm>> GetHistory()
        {
            return await Task.Run(()=> UnitOfWorkBitFinex.GetRepository().GetCollection().ToList());
        }
    }
}
