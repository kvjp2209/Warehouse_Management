using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class Warehouse : Auditable
    {
        public Warehouse()
        {
            Batches = new HashSet<Batch>();
            InventoryChecks = new HashSet<InventoryCheck>();
            Products = new HashSet<Product>();
        }

        public long WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<InventoryCheck> InventoryChecks { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
