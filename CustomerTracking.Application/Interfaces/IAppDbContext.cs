using CustomerTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Governorate> Governorates { get; }
        public DbSet<City> Cities { get; }
        public DbSet<Customer> Customers { get; }
        public DbSet<CustomerImage> CustomerImages { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
