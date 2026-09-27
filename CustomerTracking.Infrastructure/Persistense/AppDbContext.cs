using CustomerTracking.Application.Interfaces;
using CustomerTracking.Domain.Models;
using CustomerTracking.Infrastructure.DataSeeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Infrastructure.Persistense
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Governorate> Governorates => Set<Governorate>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerImage> CustomerImages => Set<CustomerImage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            SeedData.Seed(modelBuilder);
        }
    }
}
