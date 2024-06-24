using EStoreApp.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStoreApp.Persistence.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasMany(i=>i.InvoiceItems)
                .WithOne().HasForeignKey(i=>i.InvoiceId).OnDelete(DeleteBehavior.Cascade);
    }
}
