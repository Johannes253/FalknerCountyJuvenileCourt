namespace FalknerCountyJuvenileCourt.Models
{
    public class Crime
    {
        public int CrimeID { get; set; }
        public string CrimeDescription { get; set; }

        public ICollection<CrimeResult> CrimeResult { get; set; }
    }
}
