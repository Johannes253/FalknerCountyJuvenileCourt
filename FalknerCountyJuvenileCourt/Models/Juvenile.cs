using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class Juvenile
    {
        [Key]
        public int JuvenileID { get; set; }
        public int RaceID { get; set; }
        public int Risk_Assessment_ID { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
        public bool RepeatOffender { get; set; }


        public Race Race { get; set; }
       // public RiskAssessment RiskAssessment { get; set; }
        public ICollection<CrimeResult> CrimeResults { get; set; }
        
    }
}