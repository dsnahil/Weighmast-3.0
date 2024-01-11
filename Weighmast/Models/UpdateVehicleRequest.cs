﻿namespace Weighmast.Models
{
    public class UpdateVehicleRequest
    {
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public decimal TareWeight { get; set; }
        public string Notes { get; set; }
        public int AccountID { get; set; }
        public string IsActive { get; set; }
    }
}
