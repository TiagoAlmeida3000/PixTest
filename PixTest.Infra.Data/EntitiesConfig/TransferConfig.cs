using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PixTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixTest.Infra.Data.EntitiesConfig
{
    public class TransferConfig : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Value)
                .IsRequired()
                .HasPrecision(8, 2);

            builder
                .Property(t => t.PixDestinationKey)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(t => t.PixOriginKey)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(u => u.User);
        }
    }
}
