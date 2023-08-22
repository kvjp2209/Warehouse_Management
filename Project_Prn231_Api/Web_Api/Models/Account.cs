using System;
using System.Collections.Generic;
using Web_Api.Data;

namespace Web_Api.Models
{
    public partial class Account : Auditable
    {
        public long AccountId { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
    }
}
