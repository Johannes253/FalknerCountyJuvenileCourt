using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   public enum FEnum {
      DelinquencyPetitionsFiled, DivertedCases, NothingMore
   }


   public class FilingDecision {
      [Key]
      public int ID { get; set; }
      
      [Required]
      public FEnum Name { get; set; }

      public ICollection<Crime> Crimes {get;set;}

   }
}