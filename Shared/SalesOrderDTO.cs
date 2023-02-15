using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Shared
{
    public class SalesOrderDTO
    {
        public int SalesOrderID { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
        public DateTime? CreatedOn { get; set; }
        public IList<WindowDTO> Windows { get; set; }
        public bool IsNameValid { get; set; } = true;
        public bool IsStateValid { get; set; } = true;
    }
}
