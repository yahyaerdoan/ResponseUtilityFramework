using ResultHandler.Base.Results;
using ResultHandler.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Base.DataResults;

public class DataResult<T> : Result, IDataResult<T>
{
    // Property to hold the data
    public T ResultData { get; }

    // Constructor with data and success status (no custom message)
    public DataResult(T resultData, bool isSuccess) : base(isSuccess)
    {
        ResultData = resultData; // Initialize the data
    }

    // Constructor with data, success status, and custom message
    public DataResult(T resultData, bool isSuccess, string statusMessage, HttpStatusCode statusCode) : base(isSuccess, statusMessage, statusCode)
    {
        ResultData = resultData; // Initialize the data
    }    
}
