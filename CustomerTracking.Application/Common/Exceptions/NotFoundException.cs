using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerTracking.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string name, object key)
            : base($"{name} with Id '{key}' was not found.") { }
    }
}
