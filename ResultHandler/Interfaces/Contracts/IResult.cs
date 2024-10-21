using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Interfaces.Contracts;

public interface IResult
{
    bool IsSuccessful { get; }     // Indicates whether the operation was successful (true for success, false for failure)
    string StatusMessage { get; }  // Provides a message describing the result of the operation (e.g., success or error message)
    HttpStatusCode StatusCode { get; }  // Represents the HTTP status code associated with the operation (e.g., 200 for success, 400 for bad request, etc.)

}
