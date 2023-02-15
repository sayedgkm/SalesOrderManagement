using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Shared
{
    public struct ActionResultDTO<T>
    {
        public ResponseStatusCodeDTO StatusCode { get; set; }
        public T Response { get; set; }
        public string Message { get; set; }

        public static ActionResultDTO<T> Default = new ActionResultDTO<T>()
        {
            Message = string.Empty,
            StatusCode = ResponseStatusCodeDTO.Success
        };

    }
}
