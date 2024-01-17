using System;
using System.Collections.Generic;

namespace Weighmast.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string? AccountCode { get; set; }
        public string CompanyName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public ulong? IsAccount { get; set; }
        public ulong? IsTransporter { get; set; }
        public string? Notes { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public ulong Active { get; set; }
    }
}
