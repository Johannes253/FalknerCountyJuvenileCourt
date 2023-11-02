using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class IntakeDesc
    {
        [Key]
        public int IntakeDescID { get; set; }
        public string SchoolName { get; set; }

        public ICollection<CrimeResult> CrimeResult { get; set; }
    }
}
