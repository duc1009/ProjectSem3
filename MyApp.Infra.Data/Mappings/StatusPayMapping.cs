using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infra.Data.Mappings
{
    public class StatusPayMapping : IEntityTypeConfiguration<StatusPay>
    {
        public void Configure(EntityTypeBuilder<StatusPay> builder)
        {
            builder.ToTable("StatusPay");
            builder.Property(x => x.Id).HasColumnName("Id").HasMaxLength(40);
        }
    }
}
