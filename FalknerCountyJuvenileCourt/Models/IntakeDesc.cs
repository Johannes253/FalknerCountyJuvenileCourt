namespace FalknerCountyJuvenileCourt.Models
{
    public class IntakeDesc
    {
        public int IntakeDescID { get; set; }
        public string SchoolName { get; set; }

        public ICollection<CrimeResult> CrimeResult { get; set; }
    }
}
