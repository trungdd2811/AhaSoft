using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace Services.Common.Exceptions
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public ErrorResponse(Commands.CommandResult result)
        {
            ErrorCode = (int)result.ErrorCode;
            switch (result.ErrorCode)
            {
                case ErrorCodes.ObjectNotFound:
                    StatusCode = (int)HttpStatusCode.OK;
                    Message = "Object is not found";
                    break;
                case ErrorCodes.UnhandledError:
                default:
                    StatusCode = (int)HttpStatusCode.InternalServerError;
                    Message = result.Exception?.Message;
                    break;
            }
        }
        public ObjectResult GetActionResult()
        {
            ObjectResult result = new ObjectResult(this);
            result.StatusCode = StatusCode;
            return result;
        }
    }
}
