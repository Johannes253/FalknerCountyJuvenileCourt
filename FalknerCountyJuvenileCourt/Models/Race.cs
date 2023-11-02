using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class Race
    {
        [Key]
        public int RaceID { get; set; }
        public string RaceName { get; set; }

        public ICollection<Juvenile> Juveniles { get; set; }
    }
}
