using ResultHandler.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Base.Results;

public class Result : IResult
{
    // Auto-implemented properties to hold success status and message
    public bool IsSuccessful { get; }
    public string StatusMessage { get; }
    public HttpStatusCode StatusCode { get; }

    // Constructor to initialize the Result with success status and message
    public Result(bool isSuccessful, string statusMessage, HttpStatusCode statusCode)
    {
        IsSuccessful = isSuccessful;
        StatusMessage = statusMessage;
        StatusCode = statusCode;

    }

    // Overloaded constructor for initializing without a message (optional)
    public Result(bool isSuccessful)
    {
        IsSuccessful = isSuccessful;
        StatusCode = isSuccessful ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        StatusMessage = isSuccessful ? "Operation completed successfully." : "Operation failed.";
    }
}
