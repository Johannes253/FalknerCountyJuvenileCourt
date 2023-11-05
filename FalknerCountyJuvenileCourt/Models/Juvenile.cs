using System.ComponentModel.DataAnnotations;

namespace FalknerCountyJuvenileCourt.Models
{
    public class Juvenile
    {
      [Key]
      public int ID { get; set; }

      [Required]
      public int Age { get; set; }

      public int RaceID {get;set;}
      [Required]
      public Race Race { get; set; }

      public int GenderID {get;set;}
      [Required]
      public Gender Gender { get; set; }

      public int RiskID {get;set;}
      [DisplayFormat(NullDisplayText = "Unknown")]
      public Risk? Risk {get; set; }

      [Required]
      public bool Repeat { get; set; }

      public ICollection<Crime> Crimes { get; set; }

    }
}