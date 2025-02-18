using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(i => i.SaleId).HasColumnType("uuid").IsRequired();
        builder.Property(i => i.ProductId).HasColumnType("uuid").IsRequired();
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.UnitPrice).HasPrecision(18, 2).IsRequired();
        builder.Property(i => i.Discounts).HasPrecision(18, 2).IsRequired();
        builder.Property(i => i.AmountTotal).HasPrecision(18, 2).IsRequired();

        builder
            .HasOne(i => i.Product)
            .WithMany();

        builder
            .HasOne(i => i.Sale)
            .WithMany(s => s.Items);
    }
}
