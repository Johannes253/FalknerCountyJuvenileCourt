using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  


   public class Gender {
      [Key]
      public int ID { get; set; }
      
      [Required]
      public string Name { get; set; }

      public ICollection<Juvenile> Juveniles {get;set;}

   }
}