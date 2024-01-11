namespace Weighmast.Models
{
    public class UpdateDriverRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }
        public int AccountID { get; set; }
        public string IDProofScan { get; set; }
        public string IDProofType { get; set; }
        public string IDProofNo { get; set; }
        public string Active { get; set; }
    }
}
