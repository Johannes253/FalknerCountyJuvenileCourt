using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalknerCountyJuvenileCourt.Models
{  

   public class Crime {
   [Key]
   public int ID { get; set; }

   public int CrimeTypeID {get;set;}
   [Required]
   [Display(Name = "Offense")]
   public CrimeType Name { get; set; }

   public int FilingDecisionID {get;set;}
   [Required]
   [Display(Name = "Prosecutor Filing Decision")]
   public FilingDecision FilingDecision { get; set; }

   public int IntakeDecisionID {get;set;}
   [Required]
   [Display(Name = "Intake Decision")]
   public IntakeDecision IntakeDecision { get; set; }

   public int SchoolID {get;set;}
   [DisplayFormat(NullDisplayText = "Not At School")]
   public School? School { get; set; }

   [Required]
   [Display(Name = "Drug Offense")]
   public bool DrugOffense { get; set; }

   [Required]
   [Display(Name = "Drug Court")]
   public bool DrugCourt { get; set; }

   [Required]
   [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
   public DateTime Date { get; set; }

   public int JuvenileID {get;set;}
   [Required]
   public Juvenile Juvenile { get; set; }

   }
}