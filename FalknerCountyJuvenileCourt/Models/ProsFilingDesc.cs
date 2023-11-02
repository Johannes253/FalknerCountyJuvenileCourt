namespace FalknerCountyJuvenileCourt.Models
{
    public class ProsFilingDesc
    {
        public int ProsFilingDescID { get; set; }
        public string FilingDesciscion { get; set; }

        public ICollection<CrimeResult> CrimeResult { get; set; }
    }
}
