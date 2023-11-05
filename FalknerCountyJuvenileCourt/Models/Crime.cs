using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   public class Crime {
   [Key]
   public int ID { get; set; }

   public int CrimeTypeID {get;set;}
   [Required]
   public CrimeType Name { get; set; }

   public int FilingDecisionID {get;set;}
   [Required]
   public FilingDecision FilingDecision { get; set; }

   public int IntakeDecisionID {get;set;}
   [Required]
   public IntakeDecision IntakeDecision { get; set; }

   public int SchoolID {get;set;}
   [DisplayFormat(NullDisplayText = "Not At School")]
   public School? School { get; set; }

   [Required]
   public bool DrugOffense { get; set; }

   [Required]
   public bool DrugCourt { get; set; }

   [Required]
   public DateTime Date { get; set; }

   public int JuvenileID {get;set;}
   [Required]
   public Juvenile Juvenile { get; set; }

   }
}