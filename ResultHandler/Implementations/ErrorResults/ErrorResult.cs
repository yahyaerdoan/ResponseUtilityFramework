using ResultHandler.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Implementations.ErrorResults;

public class ErrorResult : Result
{
    // Default constructor with no message
    public ErrorResult() : base(false)
    {
    }

    // Constructor with custom error message
    public ErrorResult(string statusMessage, HttpStatusCode statusCode) : base(false, statusMessage, statusCode)
    {
    }
}
