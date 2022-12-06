using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalStore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Repository.Configurations
{
    internal class SkuConfiguration : IEntityTypeConfiguration<Sku>
    {
        public void Configure(EntityTypeBuilder<Sku> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.OldPrice).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
        }
    }
}
