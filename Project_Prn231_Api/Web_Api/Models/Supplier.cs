using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class Supplier : Auditable
    {
        public Supplier()
        {
            Batches = new HashSet<Batch>();
        }

        public long SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public long? AccountId { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
    }
}
