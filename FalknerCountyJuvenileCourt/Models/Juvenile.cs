using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FalknerCountyJuvenileCourt.Models
{
    public class Juvenile
    {
      [Key]
      public int ID { get; set; }

      [Required]
      public int Age { get; set; }

      public int RaceID {get;set;}

      public Race? Race { get; set; }

      public int GenderID {get;set;}

      public Gender? Gender { get; set; }

      public int RiskID {get;set;}
      [DisplayFormat(NullDisplayText = "Unknown")]
      public Risk? Risk {get; set; }


      [Display(Name = "Repeat Offender")]
      public bool Repeat { get; set; }

      public ICollection<Crime>? Crimes { get; set; }

    }
}