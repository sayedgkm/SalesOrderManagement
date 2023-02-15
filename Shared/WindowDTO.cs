using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Shared
{
    public class WindowDTO
    {
        public int WindowId { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public IList<SubElementDTO> SubElements { get; set; }
        public bool IsExpanded { get; set; } = false;
        public bool IsNameValid { get; set; } = true;
        public bool IsQuantityValid { get; set; } = true;

    }
}
