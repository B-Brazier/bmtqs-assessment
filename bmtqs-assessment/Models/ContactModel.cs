namespace bmtqs_assessment.Models
{
    public class ContactModel
    {
        public int ContactID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Companyname { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
    }
}
