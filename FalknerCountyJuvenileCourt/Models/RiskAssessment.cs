using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class RiskAssessment
    {
        [Key]
        public int RiskAssesment_ID { get; set; }
        public string Assessment { get; set; }

        public ICollection<Juvenile> Juveniles { get; set; }
    }
}
