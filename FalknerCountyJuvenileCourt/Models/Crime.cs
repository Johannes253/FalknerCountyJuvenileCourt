using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalknerCountyJuvenileCourt.Models
{  

   public class Crime {
   [Key]
   [Display(Name = "Crime")]
   public int ID { get; set; }

   public int OffenseID {get;set;}

   [Display(Name = "Offense")]
   public Offense? Offense { get; set; }

   public int FilingDecisionID {get;set;}

   [Display(Name = "Filing Decision")]
   public FilingDecision? FilingDecision { get; set; }

   public int IntakeDecisionID {get;set;}

   [Display(Name = "Intake Decision")]
   public IntakeDecision? IntakeDecision { get; set; }

   public int SchoolID {get;set;}
   [DisplayFormat(NullDisplayText = "Not At School")]
   public School? School { get; set; }


   [Display(Name = "Drug Offense")]
   public bool DrugOffense { get; set; }


   [Display(Name = "Drug Court")]
   public bool DrugCourt { get; set; }


   [DataType(DataType.Date)]
   [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
   public DateTime? Date { get; set; }

   public int JuvenileID {get;set;}

   public Juvenile? Juvenile { get; set; }

   }
}