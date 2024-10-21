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

#### Example Implementation:
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
#### Example Usage:
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
#### Example Implementation:
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
#### Example Usage:
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

### Properties:
* bool IsSuccessful: Indicates whether the operation was successful.
* string StatusMessage: A message describing the result of the operation.
* HttpStatusCode StatusCode: The HTTP status code corresponding to the result.
### Constructors:
* Result(bool isSuccessful, string statusMessage, HttpStatusCode statusCode): Initializes the Result with a success/failure flag, a custom message, and an HTTP status code.
*Result(bool isSuccessful, string statusMessage): Initializes the Result with a success/failure flag and a custom message, defaulting to HttpStatusCode.OK for success or HttpStatusCode.BadRequest for failure.
* Result(bool isSuccessful): Initializes the Result with a success/failure flag and default messages.
#### Example Usage:
```
var result = new Result(false, "An error occurred.", HttpStatusCode.BadRequest);
Console.WriteLine(result.IsSuccessful);  // Output: false
Console.WriteLine(result.StatusMessage);  // Output: An error occurred.
Console.WriteLine(result.StatusCode);     // Output: 400 (BadRequest)
```
 --- 
### 4. DataResult<T> Class
DataResult<T> extends the Result class and implements IDataResult<T>, adding the ability to return data along with the status, message, and HTTP status code. It is used when an operation returns some data.
### Properties:
T ResultData: The data returned by the operation.
### Constructors:
* DataResult(T resultData, bool isSuccessful, string statusMessage, HttpStatusCode statusCode): Initializes the DataResult with data, a success/failure flag, a message, and an HTTP status code.
* DataResult(T resultData, bool isSuccessful): Initializes the DataResult with data, a success/failure flag, and default messages.
#### Example Usage:
```
var dataResult = new DataResult<int>(42, true, "Data retrieved successfully.", HttpStatusCode.OK);
Console.WriteLine(dataResult.ResultData);  // Output: 42
Console.WriteLine(dataResult.StatusMessage);  // Output: Data retrieved successfully.
Console.WriteLine(dataResult.StatusCode);  // Output: 200 (OK)

```
---
### 5. SuccessResult Class
SuccessResult extends the Result class and represents a successful operation. It automatically sets the operation status to successful (IsSuccessful = true).

### Constructors:
* SuccessResult(string statusMessage, HttpStatusCode statusCode = HttpStatusCode.OK): Initializes the SuccessResult with a custom success message and an optional status code.
* SuccessResult(): Initializes the SuccessResult with a default message ("Operation completed successfully.") and HTTP status code HttpStatusCode.OK.
#### Example Usage:
```
var successResult = new SuccessResult("Operation succeeded.");
Console.WriteLine(successResult.IsSuccessful);   // Output: true
Console.WriteLine(successResult.StatusMessage);  // Output: Operation succeeded.
Console.WriteLine(successResult.StatusCode);     // Output: 200 (OK)

```
---  
### 6. SuccessDataResult<T> Class
The SuccessDataResult<T> class extends DataResult<T> and represents a successful operation that also returns data. It automatically sets IsSuccessful to true and allows for custom success messages and HTTP status codes.

### Constructors:
* SuccessDataResult(T resultData, string statusMessage, HttpStatusCode statusCode): Initializes the SuccessDataResult with data, a custom success message, and a custom HTTP status code.
* SuccessDataResult(T resultData): Initializes the SuccessDataResult with data, a default success message ("Operation completed successfully."), and an HTTP status code of HttpStatusCode.OK.
* SuccessDataResult(string statusMessage, HttpStatusCode statusCode): Initializes the SuccessDataResult with a custom success message, a custom HTTP status code, but no data (default(T)).
* SuccessDataResult(): Initializes the SuccessDataResult with no data (default(T)), a default success message ("Operation completed successfully."), and an HTTP status code of HttpStatusCode.OK.
  ### Example Usage:
  #### Example 1: Success with Data, Custom Message, and Custom Status Code
  ```
  var successDataResult = new SuccessDataResult<string>("Product Data", "Product retrieved successfully.", HttpStatusCode.Created);
  Console.WriteLine(successDataResult.ResultData);     // Output: Product Data
  Console.WriteLine(successDataResult.StatusMessage);  // Output: Product retrieved successfully.
  Console.WriteLine(successDataResult.StatusCode);     // Output: 201 (Created)
  ```
  #### Example 2: Success with Data and Default Message
  ```
  var successDataResult = new SuccessDataResult<int>(42);
  Console.WriteLine(successDataResult.ResultData);     // Output: 42
  Console.WriteLine(successDataResult.StatusMessage);  // Output: Operation completed successfully.
  Console.WriteLine(successDataResult.StatusCode);     // Output: 200 (OK)

  ```
  #### Example 3: Success with Custom Message and Custom Status Code (No Data)
  ```
  var successDataResult = new SuccessDataResult<string>("Product created successfully.", HttpStatusCode.Accepted);
  Console.WriteLine(successDataResult.ResultData);     // Output: null
  Console.WriteLine(successDataResult.StatusMessage);  // Output: Product created successfully.
  Console.WriteLine(successDataResult.StatusCode);     // Output: 202 (Accepted)

  ```
  #### Example 4: Default Success (No Data, No Custom Message)
  ```
  var successDataResult = new SuccessDataResult<int>();
  Console.WriteLine(successDataResult.ResultData);     // Output: 0 (default value for int)
  Console.WriteLine(successDataResult.StatusMessage);  // Output: Operation completed successfully.
  Console.WriteLine(successDataResult.StatusCode);     // Output: 200 (OK)

  ```  
---
### 7. ErrorResult Class
ErrorResult extends the Result class and represents a failed operation. It automatically sets the operation status to failed (IsSuccessful = false).

### Constructors:
* ErrorResult(string statusMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest): Initializes the ErrorResult with a custom error message and an optional status code.
* ErrorResult(): Initializes the ErrorResult with a default error message ("An error occurred.") and status code HttpStatusCode.BadRequest.
#### Example Usage:
```
var errorResult = new ErrorResult("Operation failed.", HttpStatusCode.InternalServerError);
Console.WriteLine(errorResult.IsSuccessful);   // Output: false
Console.WriteLine(errorResult.StatusMessage);  // Output: Operation failed.
Console.WriteLine(errorResult.StatusCode);     // Output: 500 (InternalServerError)

```
---
### 8. ErrorDataResult<T> Class
ErrorDataResult<T> extends DataResult<T> and represents a failed operation that may return data.

### Constructors:
* ErrorDataResult(T resultData, string statusMessage, HttpStatusCode statusCode): Initializes the ErrorDataResult with data, a custom error message, and a custom status code.
* ErrorDataResult(T resultData): Initializes the ErrorDataResult with data, a default error message, and a default status code.
* ErrorDataResult(string statusMessage, HttpStatusCode statusCode): Initializes the ErrorDataResult with a custom error message and status code, but no data.
* ErrorDataResult(): Initializes the ErrorDataResult with no data, a default error message, and status code HttpStatusCode.BadRequest.

### Example Usage:
#### Example 1: Error with Data, Custom Message, and Custom Status Code
```
var errorDataResult = new ErrorDataResult<string>(null, "Product not found.", HttpStatusCode.NotFound);
Console.WriteLine(errorDataResult.IsSuccessful);   // Output: false
Console.WriteLine(errorDataResult.StatusMessage);  // Output: Product not found.
Console.WriteLine(errorDataResult.StatusCode);     // Output: 404 (NotFound)
Console.WriteLine(errorDataResult.ResultData);     // Output: null

```
#### Example 2: Error with Data and Default Message
```
var errorDataResult = new ErrorDataResult<string>("Invalid data");
Console.WriteLine(errorDataResult.IsSuccessful);   // Output: false
Console.WriteLine(errorDataResult.StatusMessage);  // Output: An error occurred.
Console.WriteLine(errorDataResult.StatusCode);     // Output: 400 (BadRequest)
Console.WriteLine(errorDataResult.ResultData);     // Output: Invalid data

```
#### Example 3: Error with Custom Message and Status Code (No Data)
```
var errorDataResult = new ErrorDataResult<string>("Product not found", HttpStatusCode.NotFound);
Console.WriteLine(errorDataResult.IsSuccessful);   // Output: false
Console.WriteLine(errorDataResult.StatusMessage);  // Output: Product not found.
Console.WriteLine(errorDataResult.StatusCode);     // Output: 404 (NotFound)
Console.WriteLine(errorDataResult.ResultData);     // Output: null

```
#### Example 4: Default Error (No Data, Default Message)
```
var errorDataResult = new ErrorDataResult<int>();
Console.WriteLine(errorDataResult.IsSuccessful);   // Output: false
Console.WriteLine(errorDataResult.StatusMessage);  // Output: An error occurred.
Console.WriteLine(errorDataResult.StatusCode);     // Output: 400 (BadRequest)
Console.WriteLine(errorDataResult.ResultData);     // Output: 0 (default value for int)

```
### Conclusion
These interfaces and classes provide a robust and flexible system for handling both success and error cases in your application. 
The result system includes status messages, HTTP status codes, and optional data, making it easy to standardize and maintain responses across different layers of your application, particularly in RESTful APIs.






