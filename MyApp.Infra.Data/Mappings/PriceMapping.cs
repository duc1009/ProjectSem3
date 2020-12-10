using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infra.Data.Mappings
{
    public class PriceMapping : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Price");
            builder.Property(x => x.Id).HasColumnName("Id").HasMaxLength(40);
            builder.Property(x => x.MaterialId).HasMaxLength(40);
            builder.Property(x => x.SizeId).HasMaxLength(40);
        }
    }
}
