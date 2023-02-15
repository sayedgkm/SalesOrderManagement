using SalesOrderManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Core.Utilities
{
    public class FunctionResult<T>
    {
        public ResponseStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Response { get; set; }

        public static FunctionResult<T> Default = new FunctionResult<T>()
        {
            Message = string.Empty,
            StatusCode = ResponseStatusCode.Success
        };
    }
}
