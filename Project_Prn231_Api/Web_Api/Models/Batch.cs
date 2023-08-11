using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class Batch : Auditable
    {
        public long BatchId { get; set; }
        public long ProductId { get; set; }
        public int? QuantityIn { get; set; }
        public int? QuantityOut { get; set; }
        public DateTime? ImportDate { get; set; }
        public DateTime? ExportDate { get; set; }
        public long SupplierId { get; set; }
        public long WarehouseId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
