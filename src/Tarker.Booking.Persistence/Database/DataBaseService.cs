using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Persistence.Configuration;


namespace Tarker.Booking.Persistence.Database
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<UserEntity> User { get; set; } 
        public DbSet<BookingEntity> Booking { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }

        // Devuelve un valor booleano que indica si se ha guardado correctamente
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        // Invoca configuraciones de las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }


        // Configuración de las entidades
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
        }


    }
}
