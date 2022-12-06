using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalStore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Repository.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "deneme@gmail.com",
                TCID = 11111111111,
                Birthdate = DateTime.Now,
                Gsm = "123456789"
            });
        }
    }
}
