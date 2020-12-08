using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infra.Data.Mappings
{
    public class SizeMapping : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Size");
            builder.Property(x => x.Id).HasColumnName("Id").HasMaxLength(40);
        }
    }
}
