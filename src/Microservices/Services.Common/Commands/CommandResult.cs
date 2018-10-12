using System;
using System.Collections.Generic;
using System.Text;
using Services.Common.Exceptions;
namespace Services.Common.Commands
{
    public class CommandResult
    {
        public bool IsOK { get; private set; }
        public Exception Exception { get; private set; }
        public ErrorCodes ErrorCode { get; private set; } 
        public CommandResult (bool isOK, Exception exception = null, ErrorCodes errorCode = ErrorCodes.NoError)
        {
            IsOK = isOK;
            Exception = exception;
            if ((!IsOK || exception !=null) && ErrorCode == ErrorCodes.NoError)
                ErrorCode = ErrorCodes.UnhandledError;
        }
    }
}
