using System;
using System.Collections.Generic;

namespace Weighmast.Models
{
    public partial class Weighbridge
    {
        public int WeighbridgeId { get; set; }
        public string ScaleName { get; set; } = null!;
        public string? MaxCapacity { get; set; }
        public ulong IsActive { get; set; }
        public string? Unit { get; set; }
        public string ConnectionType { get; set; } = null!;
        public string SerialPort { get; set; } = null!;
        public string DataBits { get; set; } = null!;
        public int BaudRate { get; set; }
        public int StopBits { get; set; }
        public string Parity { get; set; } = null!;
        public int TotalStringLength { get; set; }
        public string Format { get; set; } = null!;
        public string StartStringCharacter { get; set; } = null!;
        public int NewLine { get; set; }
        public string? IsDecimalCharacterInString { get; set; }
        public string? WeightStartFrom { get; set; }
        public string? ReverseString { get; set; }
        public string? WeightLength { get; set; }
        public string? Handshake { get; set; }
        public int? IndicatorId { get; set; }
    }
}
