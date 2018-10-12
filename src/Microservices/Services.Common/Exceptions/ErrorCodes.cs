using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.Exceptions
{
    public enum ErrorCodes
    {
        NoError = 0,
        InternalError = 1,
        ObjectNotFound = 2,
        ObjectDuplicated = 3,
        UnhandledError = 4
    }
}
