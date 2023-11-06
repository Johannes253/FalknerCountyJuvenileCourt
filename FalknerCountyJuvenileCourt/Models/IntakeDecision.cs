using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   public enum IEnum {
      CiteAndRelease, DetentionAlternative, Detention
   }


   public class IntakeDecision {
      [Key]
      public int ID { get; set; }
      
      [Required]
      public IEnum Name { get; set; }

      public ICollection<Crime> Crimes {get;set;}

   }
}