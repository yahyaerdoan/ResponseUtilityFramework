using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultHandler.Interfaces.Contracts;

public interface IDataResult<T> : IResult
{
    T ResultData { get; }  // Clearer indication of the data being returned
}
