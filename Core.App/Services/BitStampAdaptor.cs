using AutoMapper;
using Core.App.ApiModels.BitStamp;
using Core.Interfaces.Interfaces.IData;
using Domain.Entities.BitStamp;

namespace Core.App.Services
{
    public class BitStampAdaptor<TApim, TEntm>
        where TApim : BitStampModel
        where TEntm : TbBitStamp
    {
        public BitStampAdaptor(IMapper mapper, IUnitOfWork<TEntm> unitOfWorkBitStamp)
        {
            Mapper = mapper;
            UnitOfWorkBitStamp = unitOfWorkBitStamp;
        }

        public IMapper Mapper { get; }
        public IUnitOfWork<TEntm> UnitOfWorkBitStamp { get; }

        public async Task AddModel(IEnumerable<TApim> bitStampModels)
        {
            if (!bitStampModels?.Any() ?? false) return;
            var mapped = Mapper.Map<TApim, TEntm>(bitStampModels.FirstOrDefault());
            await UnitOfWorkBitStamp.GetRepository().InsertOrUpdate(mapped);
        }
    }
}
