using SalesOrderManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Core.Domain
{
    public class SubElement: BaseEntity
    {
        public int? Width { get; set; }
        public int? Height { get; set; }
        public DateTime? CreatedOn { get; set; }
        public SubElementType ElementType { get; set; }
        public int WindowId { get; set; }
        public Window? Window { get; set; }
    }
}
