namespace Empleo.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string LogoCompany { get; set; }
        public string OfferTitle { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public int Positions { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
        public string Languages { get; set; }
    }
}