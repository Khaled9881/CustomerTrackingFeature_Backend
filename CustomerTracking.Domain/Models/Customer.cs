using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; } = null!;

        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<CustomerImage> Images { get; set; } = new List<CustomerImage>();
    }
}
