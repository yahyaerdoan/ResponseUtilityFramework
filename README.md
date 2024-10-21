# Documentation: Result Handling Classes and Interfaces
## Overview
#### This set of interfaces and classes is designed to standardize the structure of responses across your application, particularly for operations that return data, success/failure status, messages, and HTTP status codes. 
#### The interfaces provide a common contract for handling results, and the classes implement these interfaces to handle both success and error cases.
---
### 1. IResult Interface
The IResult interface is the base contract for all result types. 
It defines the common properties that every result (success or error) should have, including whether the operation was successful, a status message, and an HTTP status code.
### Properties:
* bool IsSuccessful: Indicates whether the operation was successful (true for success, false for failure).
* string StatusMessage: A message that provides additional context, such as a success message or an error message.
* HttpStatusCode StatusCode: The HTTP status code associated with the result, which can be used for RESTful responses.

### Example Implementation:
```
public class DataResult<T> : IDataResult<T>
{
    public bool IsSuccessful { get; }
    public string StatusMessage { get; }
    public HttpStatusCode StatusCode { get; }
    public T ResultData { get; }

    public DataResult(T resultData, bool isSuccessful, string statusMessage, HttpStatusCode statusCode)
    {
        ResultData = resultData;
        IsSuccessful = isSuccessful;
        StatusMessage = statusMessage;
        StatusCode = statusCode;
    }
}

```
### Example Usage:
```
var result = new Result(true, "Operation completed successfully.", HttpStatusCode.OK);
Console.WriteLine(result.IsSuccessful);  // Output: true
Console.WriteLine(result.StatusMessage);  // Output: Operation completed successfully.
Console.WriteLine(result.StatusCode);     // Output: 200 (OK)
```
---
### 2. IDataResult<T> Interface
IDataResult<T> extends IResult by adding support for returning data along with the status, message, and HTTP status code. 
This interface is useful when the result of an operation includes some data in addition to success or failure information.

### Properties:
* T ResultData: The data returned by the operation. It could be any type (T), or null if no data is returned.
### Example Implementation:
```
public class DataResult<T> : IDataResult<T>
{
    public bool IsSuccessful { get; }
    public string StatusMessage { get; }
    public HttpStatusCode StatusCode { get; }
    public T ResultData { get; }

    public DataResult(T resultData, bool isSuccessful, string statusMessage, HttpStatusCode statusCode)
    {
        ResultData = resultData;
        IsSuccessful = isSuccessful;
        StatusMessage = statusMessage;
        StatusCode = statusCode;
    }
}
```
### Example Usage:
```
var dataResult = new DataResult<string>("Product Data", true, "Operation succeeded.", HttpStatusCode.OK);
Console.WriteLine(dataResult.ResultData);  // Output: Product Data
Console.WriteLine(dataResult.IsSuccessful);  // Output: true
Console.WriteLine(dataResult.StatusMessage);  // Output: Operation succeeded.
Console.WriteLine(dataResult.StatusCode);  // Output: 200 (OK)
```
---
### 3. Result Class
The Result class implements the IResult interface. It represents the outcome of an operation, whether successful or not, along with a message and HTTP status code.

###Properties:
* bool IsSuccessful: Indicates whether the operation was successful.
* string StatusMessage: A message describing the result of the operation.
* HttpStatusCode StatusCode: The HTTP status code corresponding to the result.
### Constructors:
* Result(bool isSuccessful, string statusMessage, HttpStatusCode statusCode): Initializes the Result with a success/failure flag, a custom message, and an HTTP status code.
*Result(bool isSuccessful, string statusMessage): Initializes the Result with a success/failure flag and a custom message, defaulting to HttpStatusCode.OK for success or HttpStatusCode.BadRequest for failure.
* Result(bool isSuccessful): Initializes the Result with a success/failure flag and default messages.
 --- 
### 4. DataResult<T> Class
DataResult<T> extends the Result class and implements IDataResult<T>, adding the ability to return data along with the status, message, and HTTP status code. It is used when an operation returns some data.
### Properties:
T ResultData: The data returned by the operation.
### Constructors:
* DataResult(T resultData, bool isSuccessful, string statusMessage, HttpStatusCode statusCode): Initializes the DataResult with data, a success/failure flag, a message, and an HTTP status code.
* DataResult(T resultData, bool isSuccessful): Initializes the DataResult with data, a success/failure flag, and default messages.
---
### 5. SuccessResult Class
SuccessResult extends the Result class and represents a successful operation. It automatically sets the operation status to successful (IsSuccessful = true).

### Constructors:
* SuccessResult(string statusMessage, HttpStatusCode statusCode = HttpStatusCode.OK): Initializes the SuccessResult with a custom success message and an optional status code.
* SuccessResult(): Initializes the SuccessResult with a default message ("Operation completed successfully.") and HTTP status code HttpStatusCode.OK.
---  
### 6. SuccessDataResult<T> Class
The SuccessDataResult<T> class extends DataResult<T> and represents a successful operation that also returns data. It automatically sets IsSuccessful to true and allows for custom success messages and HTTP status codes.

### Constructors:
* SuccessDataResult(T resultData, string statusMessage, HttpStatusCode statusCode): Initializes the SuccessDataResult with data, a custom success message, and a custom HTTP status code.
* SuccessDataResult(T resultData): Initializes the SuccessDataResult with data, a default success message ("Operation completed successfully."), and an HTTP status code of HttpStatusCode.OK.
* SuccessDataResult(string statusMessage, HttpStatusCode statusCode): Initializes the SuccessDataResult with a custom success message, a custom HTTP status code, but no data (default(T)).
* SuccessDataResult(): Initializes the SuccessDataResult with no data (default(T)), a default success message ("Operation completed successfully."), and an HTTP status code of HttpStatusCode.OK.
---
### 7. ErrorResult Class
ErrorResult extends the Result class and represents a failed operation. It automatically sets the operation status to failed (IsSuccessful = false).

### Constructors:
* ErrorResult(string statusMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest): Initializes the ErrorResult with a custom error message and an optional status code.
* ErrorResult(): Initializes the ErrorResult with a default error message ("An error occurred.") and status code HttpStatusCode.BadRequest.
---
### 8. ErrorDataResult<T> Class
ErrorDataResult<T> extends DataResult<T> and represents a failed operation that may return data.

### Constructors:
* ErrorDataResult(T resultData, string statusMessage, HttpStatusCode statusCode): Initializes the ErrorDataResult with data, a custom error message, and a custom status code.
* ErrorDataResult(T resultData): Initializes the ErrorDataResult with data, a default error message, and a default status code.
* ErrorDataResult(string statusMessage, HttpStatusCode statusCode): Initializes the ErrorDataResult with a custom error message and status code, but no data.
* ErrorDataResult(): Initializes the ErrorDataResult with no data, a default error message, and status code HttpStatusCode.BadRequest.





