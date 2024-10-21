using ResultHandler.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Implementations.SuccessResults;

public class SuccessResult : Result
{

    // Constructor with a custom success message and HTTP status code (default to OK)
    public SuccessResult(string statusMessage, HttpStatusCode statusCode = HttpStatusCode.OK) : base(true, statusMessage, statusCode)
    {
    }

    // Default constructor with a default success message and status code OK
    public SuccessResult() : base(true, "Operation completed successfully.", HttpStatusCode.OK)
    {
    }
}
