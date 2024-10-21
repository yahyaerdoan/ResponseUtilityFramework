using ResultHandler.Base.DataResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Implementations.SuccessResults;

public class SuccessDataResult<T> : DataResult<T?>
{
    // Constructor with data, custom success message, and custom status code
    public SuccessDataResult(T resultData, string statusMessage, HttpStatusCode statusCode) : base(resultData, true, statusMessage, statusCode)
    {
    }

    // Constructor with only data, default success message
    public SuccessDataResult(T resultData) : base(resultData, true, "Operation completed successfully.", HttpStatusCode.OK)
    {
    }

    // Constructor with custom success message (no data) and custom status code
    public SuccessDataResult(string statusMessage, HttpStatusCode statusCode) : base(default, true, statusMessage, statusCode)
    {
    }

    // Default constructor (no data, default success message, and success state)
    public SuccessDataResult() : base(default, true, "Operation completed successfully.", HttpStatusCode.OK)
    {
    }
}
