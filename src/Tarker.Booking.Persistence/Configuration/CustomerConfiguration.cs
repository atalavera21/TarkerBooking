using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> customerBuilder)
        {
            customerBuilder.HasKey(x => x.CustomerId);
            customerBuilder.Property(x => x.FullName).IsRequired();
            customerBuilder.Property(x => x.DocumentNumber).IsRequired();

            customerBuilder.HasMany(x => x.Bookings)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
