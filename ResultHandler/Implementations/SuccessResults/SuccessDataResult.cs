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
    // Constructor with data and custom success message
    public SuccessDataResult(T resultData, string statusMessage) : base(resultData, true, statusMessage, HttpStatusCode.OK)
    {
    }

    // Constructor with only data, default success message
    public SuccessDataResult(T resultData) : base(resultData, true, "Operation completed successfully.", HttpStatusCode.OK)
    {
    }

    // Constructor with no data, but with custom success message
    public SuccessDataResult(string statusMessage) : base(default, true, statusMessage, HttpStatusCode.OK)
    {
    }

    // Default constructor (no data, default success message, and success state)
    public SuccessDataResult() : base(default, true, "Operation completed successfully.", HttpStatusCode.OK)
    {
    }
}
