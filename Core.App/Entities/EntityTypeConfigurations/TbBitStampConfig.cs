using Core.App.Entities.BitStamp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.App.Entities.EntityTypeConfigurations
{
    internal sealed class TbBitStampConfig : IEntityTypeConfiguration<TbBitStamp>
    {
        public void Configure(EntityTypeBuilder<TbBitStamp> builder)
        {
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.timestamp).HasColumnType("integer").HasColumnName(nameof(TbBitStamp.timestamp)).IsRequired();
            builder.Property(x => x.open).HasColumnType("money").HasColumnName(nameof(TbBitStamp.open));
            builder.Property(x => x.close).HasColumnType("money").HasColumnName(nameof(TbBitStamp.close));
            builder.Property(x => x.high).HasColumnType("money").HasColumnName(nameof(TbBitStamp.high));
            builder.Property(x => x.low).HasColumnType("money").HasColumnName(nameof(TbBitStamp.low));
            builder.Property(x => x.last).HasColumnType("money").HasColumnName(nameof(TbBitStamp.last));
            builder.Property(x => x.volume).HasColumnType("money").HasColumnName(nameof(TbBitStamp.volume));
            builder.Property(x => x.vwap).HasColumnType("integer").HasColumnName(nameof(TbBitStamp.vwap));
            builder.Property(x => x.bid).HasColumnType("money").HasColumnName(nameof(TbBitStamp.bid));
            builder.Property(x => x.ask).HasColumnType("money").HasColumnName(nameof(TbBitStamp.ask));
            builder.Property(x => x.open_24).HasColumnType("money").HasColumnName(nameof(TbBitStamp.open_24));
            builder.Property(x => x.percent_change_24).HasColumnType("integer").HasColumnName(nameof(TbBitStamp.percent_change_24));
            builder.ToTable(nameof(TbBitStamp));
        }
    }
}
