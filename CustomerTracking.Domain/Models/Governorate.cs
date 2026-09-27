using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Domain.Models
{
    public class Governorate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<City> Cities { get; set; } = new List<City>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
