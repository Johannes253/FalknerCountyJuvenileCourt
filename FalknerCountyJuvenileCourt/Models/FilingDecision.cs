using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   public class FilingDecision {
      [Key]
      public int ID { get; set; }
      
      [Required]
      public string Name { get; set; }

      public ICollection<Crime> Crimes {get;set;}

   }
}