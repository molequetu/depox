using depox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace depox.Infrastructure.Data.Config
{
    public class BinConfiguration : IEntityTypeConfiguration<Bin>
    {
        public void Configure(EntityTypeBuilder<Bin> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}