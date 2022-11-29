using Core.App.Entities.BitStamp;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.App.Entities.BitFinex;

namespace Core.App.Entities.EntityTypeConfigurations
{
    internal class TbBitFinexConfig : IEntityTypeConfiguration<TbBitFinex>
    {
        public void Configure(EntityTypeBuilder<TbBitFinex> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.timestamp).HasColumnType("integer").HasColumnName(nameof(TbBitFinex.timestamp)).IsRequired();
            builder.Property(x => x.mid).HasColumnType("money").HasColumnName(nameof(TbBitFinex.mid));
            builder.Property(x => x.bid).HasColumnType("money").HasColumnName(nameof(TbBitFinex.bid));
            builder.Property(x => x.ask).HasColumnType("money").HasColumnName(nameof(TbBitFinex.ask));
            builder.Property(x => x.last_price).HasColumnType("money").HasColumnName(nameof(TbBitFinex.last_price));
            builder.Property(x => x.low).HasColumnType("money").HasColumnName(nameof(TbBitFinex.low));
            builder.Property(x => x.high).HasColumnType("money").HasColumnName(nameof(TbBitFinex.high));
            builder.Property(x => x.volume).HasColumnType("money").HasColumnName(nameof(TbBitFinex.volume));
            builder.ToTable(nameof(TbBitStamp));
        }
    }
}
