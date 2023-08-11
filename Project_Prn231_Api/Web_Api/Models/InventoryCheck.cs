using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class InventoryCheck : Auditable
    {
        public long InventoryCheckId { get; set; }
        public DateTime? CheckDate { get; set; }
        public long WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
