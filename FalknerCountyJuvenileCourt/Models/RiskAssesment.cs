namespace FalknerCountyJuvenileCourt.Models
{
    public class RiskAssessment
    {
        public int RiskAssessmentID { get; set; }
        public string Assesment { get; set; }

        public ICollection<Juvenile> Juveniles { get; set; }
    }
}
