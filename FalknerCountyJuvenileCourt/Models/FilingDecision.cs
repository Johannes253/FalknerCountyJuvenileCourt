using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   public class FilingDecision {
      [Key]
      public int ID { get; set; }
      

      // [Display(Name = "Drug Offense")]
      public string Name { get; set; }

      public ICollection<Crime>? Crimes {get;set;}

      public override string ToString()
      {
        return Name;
      }

   }
}