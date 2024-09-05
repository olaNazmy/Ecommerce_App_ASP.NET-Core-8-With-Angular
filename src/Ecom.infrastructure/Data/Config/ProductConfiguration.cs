using Ecom.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Data.Config
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Price).HasColumnType("decimal(18,10)");
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.categoryId);

            // Seed data
            builder.HasData(
                new Product { Id = 1, Name = "Laptop",Description="product 1" ,Price = 999.99m, categoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Description = "product 2", Price = 699.99m, categoryId = 1 },
                new Product { Id = 3, Name = "Novel", Description = "product 2", Price = 19.99m, categoryId = 2 }
            );

        }

    }
}
