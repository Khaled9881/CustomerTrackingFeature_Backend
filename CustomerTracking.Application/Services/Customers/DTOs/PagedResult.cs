using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Services.Customers.DTOs
{
    public record PagedResult<T>(IEnumerable<T> Items, int TotalCount, int Page, int PageSize);
}
