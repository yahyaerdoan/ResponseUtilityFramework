using ResultHandler.Base.DataResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Implementations.ErrorResults;

public class ErrorDataResult<T> : DataResult<T?>
{
    // Constructor with data, custom error message, and custom status code
    public ErrorDataResult(T resultData, string statusMessage, HttpStatusCode statusCode) : base(resultData, false, statusMessage,  statusCode)
    {
    }

    // Constructor with data only (default error message and default status code)
    public ErrorDataResult(T resultData) : base(resultData, false, "An error occurred.", HttpStatusCode.BadRequest)
    {
    }

    // Constructor with custom error message (no data) and custom status code
    public ErrorDataResult(string statusMessage, HttpStatusCode statusCode) : base(default, false, statusMessage, statusCode)
    {
    }

    // Default constructor (no data, default error message, and status code)
    public ErrorDataResult() : base(default, false, "An error occurred.", HttpStatusCode.BadRequest)
    {
    }    
}
