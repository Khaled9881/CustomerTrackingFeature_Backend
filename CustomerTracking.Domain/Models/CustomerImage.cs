using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Domain.Models
{
    public class CustomerImage
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public string ImagePath { get; set; } = string.Empty;
        public bool IsMain { get; set; }
    }
}
