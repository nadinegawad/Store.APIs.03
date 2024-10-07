using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.G03.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G03.Repository.Data.configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).HasMaxLength(200).IsRequired();
            builder.Property(P => P.PictureUrl).IsRequired();
            builder.Property(P => P.Price).HasColumnType("decimal(18,2)");
            builder.Property(P => P.TypeId).IsRequired(false);
            builder.Property(P => P.BrandId).IsRequired(false);
        }
    }
}
