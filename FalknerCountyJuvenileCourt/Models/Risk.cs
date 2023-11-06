using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   public enum REnum {
      Unknown, High, Medium, Low
   }


   public class Risk
   {
   [Key]
   public int ID { get; set; }
   
   [Required]
   public REnum Name { get; set; }

   public ICollection<Juvenile> Juveniles {get;set;}

   }
}