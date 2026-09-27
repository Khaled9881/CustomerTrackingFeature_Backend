using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Location.DTOs
{
    public class CityDto
    {
        public CityDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
