using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.Number).UseIdentityByDefaultColumn().IsRequired();
        builder.Property(s => s.CustomerId).HasColumnType("uuid").IsRequired();
        builder.Property(s => s.AmountTotal).HasPrecision(18, 2).IsRequired();
        builder.Property(s => s.Cancelled).IsRequired();
        builder.Property(s => s.CreatedAt).IsRequired();
        builder.Property(s => s.UpdatedAt);

        builder.HasIndex(s => s.Number).IsUnique();

        builder
            .HasOne(s => s.Customer)
            .WithMany();

        builder
            .HasMany(s => s.Items)
            .WithOne(i => i.Sale);
    }
}
