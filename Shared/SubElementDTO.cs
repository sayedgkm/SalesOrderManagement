using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Shared
{
    public class SubElementDTO
    {
        public int SubElementId { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public DateTime? CreatedOn { get; set; }
        public SubElementTypeDTO ElementType { get; set; }
        public bool IsWidthValid { get; set; } = true;
        public bool IsHeightValid { get; set; } = true;
    }
}
