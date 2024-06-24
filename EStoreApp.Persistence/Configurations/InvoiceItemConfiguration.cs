using EStoreApp.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStoreApp.Persistence.Configurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.HasOne(i=>i.Product)
            .WithMany(i=>i.InvoiceItems).HasForeignKey(i=>i.ProductId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i=>i.Invoice)
            .WithMany(i=>i.InvoiceItems).HasForeignKey(i=>i.InvoiceId).OnDelete(DeleteBehavior.Cascade);

        builder.Property(i=>i.Quantity).HasColumnType("decimal(18,6)");
    }
}
