using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class Schools
    {
        [Key]
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }

        public ICollection<CrimeResult> CrimeResult { get; set; }
    }
}
