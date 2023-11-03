using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class RiskAssesment
    {
        [Key]
        public int RiskAssesment_ID { get; set; }
        public string RiskAssesmentName { get; set; }

        public ICollection<Juvenile> Juveniles { get; set; }
    }
}
