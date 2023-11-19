using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  


   public class IntakeDecision {
      [Key]
      public int ID { get; set; }
      

      public string Name { get; set; }

      public ICollection<Crime>? Crimes {get;set;}
      
      public override string ToString()
      {
        return Name;
      }

   }
}