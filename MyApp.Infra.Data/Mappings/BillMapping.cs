using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infra.Data.Mappings
{
    public class BillDetailMapping : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("BillDetail");
            builder.Property(x => x.Id).HasColumnName("Id").HasMaxLength(40);
            builder.Property(x => x.BillId).HasMaxLength(40);
            builder.Property(x => x.SizeId).HasMaxLength(40);
            builder.Property(x => x.MaterialId).HasMaxLength(40);
        }
    }
}
