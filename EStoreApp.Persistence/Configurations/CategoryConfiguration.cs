using EStoreApp.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStoreApp.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasIndex(c => c.Name).IsUnique();
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Name).HasMaxLength(50);

        builder.HasMany(c => c.Products)
                .WithOne(p=>p.Category)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);

       
    }
}
