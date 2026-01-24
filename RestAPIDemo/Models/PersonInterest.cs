namespace RestAPIDemo.Models
{
    public class PersonInterest
    {   
        public int PersonInterestId { get; set; }
        public int PersonId { get; set; }
        
        public int InterestId { get; set; }

        public Person Person { get; set; }
        public Interest Interest { get; set; }
    }
}
