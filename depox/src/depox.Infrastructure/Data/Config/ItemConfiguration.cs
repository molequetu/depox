using depox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace depox.Infrastructure.Data.Config
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);


            builder.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(i => i.StockQuantity)
                .HasDefaultValue(0);


            //builder.HasOne(ci => ci.Bin)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.BinId);
        }
    }
}