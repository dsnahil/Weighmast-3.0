namespace Weighmast.Models
{
    public class AddVehicleRequest
    {
        public int VehicleID { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public decimal TareWeight { get; set; }
        public string Notes { get; set; }
        public int AccountID { get; set; }
        public string IsActive { get; set; }
    }
}
