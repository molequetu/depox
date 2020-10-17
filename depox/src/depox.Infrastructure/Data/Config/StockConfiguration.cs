using depox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace depox.Infrastructure.Data.Config
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.BinId)
                .IsRequired();

            builder.Property(c => c.ItemId)
                .IsRequired();

            builder.Property(c => c.ActionType)
                .IsRequired();

            builder.Property(c => c.Quantity)
                .IsRequired();
        }
    }
}