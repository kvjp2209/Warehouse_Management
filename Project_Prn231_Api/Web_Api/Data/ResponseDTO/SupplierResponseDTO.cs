﻿namespace Web_Api.Data.ResponseDTO
{
    public class SupplierResponseDTO
    {
        public long SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public long? AccountId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
