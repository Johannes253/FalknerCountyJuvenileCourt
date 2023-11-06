using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   public enum GEnum {
      Male, Female
   }


   public class Gender {
      [Key]
      public int ID { get; set; }
      
      [Required]
      public GEnum Name { get; set; }

      public ICollection<Juvenile> Juveniles {get;set;}

   }
}