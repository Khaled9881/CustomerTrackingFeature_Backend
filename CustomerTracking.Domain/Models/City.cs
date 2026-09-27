using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; } = null!;

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
