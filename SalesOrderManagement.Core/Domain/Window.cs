using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Core.Domain
{
    public class Window : BaseEntity
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public IList<SubElement> SubElements { get; set; }
    }
}
