using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class ProsFilingDesc
    {
        [Key]
        public int ProsFilingDescID { get; set; }
        public string FilingDesciscion { get; set; }

        public ICollection<CrimeResult> CrimeResult { get; set; }
    }
}
