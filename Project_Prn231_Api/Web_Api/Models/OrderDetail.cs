using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class OrderDetail : Auditable
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
