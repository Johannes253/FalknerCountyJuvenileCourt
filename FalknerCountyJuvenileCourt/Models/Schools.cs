namespace FalknerCountyJuvenileCourt.Models
{
    public class Schools
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }

        public ICollection<CrimeResult> CrimeResult { get; set; }
    }
}
