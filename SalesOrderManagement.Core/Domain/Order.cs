using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Core.Domain
{
    public class Order : BaseEntity
    {
        public string? Name { get; set; }
        public string? State { get; set; }
        public DateTime? CreatedOn { get; set; }
        public IList<Window> Windows { get; set; }
    }
}
