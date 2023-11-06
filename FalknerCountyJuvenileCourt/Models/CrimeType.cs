using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{  

   // public enum CEnum {
   //    Battery, Etc
   // }


   public class CrimeType
   {
   [Key]
   public int ID { get; set; }
   
   [Required]
   public string Type { get; set; }

   public ICollection<Crime> Crimes {get; set;}

   }
}