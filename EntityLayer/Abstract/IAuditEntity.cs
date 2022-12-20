using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
        public interface IAuditEntity
    {
        int CreatedObjectId { get; set; } //rezervasyon vs için de ekleyelim mi??
        DateTime? CreatedDate { get; set; }
         int UpdatedObjectId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
