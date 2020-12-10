using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infra.Data.Mappings
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.Property(x => x.Id).HasColumnName("Id").HasMaxLength(40);
        }
    }
}
