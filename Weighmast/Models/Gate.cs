using System;
using System.Collections.Generic;

namespace Weighmast.Models
{
    public partial class Gate
    {
        public int GateId { get; set; }
        public string GateName { get; set; } = null!;
        public string Note { get; set; } = null!;
        public string GateType { get; set; } = null!;
        public ulong Active { get; set; }
    }
}
