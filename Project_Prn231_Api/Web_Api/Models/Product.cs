using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class Product : Auditable
    {
        public Product()
        {
            Batches = new HashSet<Batch>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public long WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; } = null!;
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
