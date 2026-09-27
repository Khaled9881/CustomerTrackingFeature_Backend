using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.DTOs
{
    public record CustomerImageDto(
    int Id,
    string ImagePath,
    bool IsMain
    );
}
