using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  


   public class Gender {
      [Key]
      public int ID { get; set; }
      

      public string Name { get; set; }

      public ICollection<Juvenile>? Juveniles {get;set;}

      public override string ToString()
      {
        return Name;
      }

   }
}