using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  


   public class IntakeDecision {
      [Key]
      public int ID { get; set; }
      
      [Required]
      public string Name { get; set; }

      public ICollection<Crime> Crimes {get;set;}

   }
}