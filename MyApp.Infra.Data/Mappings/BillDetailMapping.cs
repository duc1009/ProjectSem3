using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infra.Data.Mappings
{
    public class BillMapping : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.Property(x => x.Id).HasColumnName("Id").HasMaxLength(40);
            builder.Property(x => x.UserId).HasMaxLength(40);
            builder.Property(x => x.StatusId).HasMaxLength(40);
            builder.Property(x => x.StatusPayId).HasMaxLength(40);
            builder.Property(x => x.PaymentId).HasMaxLength(40);
        }
    }
}
