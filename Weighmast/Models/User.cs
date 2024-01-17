using System;
using System.Collections.Generic;

namespace Weighmast.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string UserRole { get; set; } = null!;
        public string? Notes { get; set; }
        public ulong Active { get; set; }
    }
}
