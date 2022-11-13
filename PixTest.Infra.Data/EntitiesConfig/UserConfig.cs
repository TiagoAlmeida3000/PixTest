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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(u => u.Document)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.PixKey)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasMany(t => t.Transfers)
                .WithOne(u => u.User);
        }
    }
}
