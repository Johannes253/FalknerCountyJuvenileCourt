using System.ComponentModel.DataAnnotations;
namespace FalknerCountyJuvenileCourt.Models
{
    public class School
    {
        [Key]
        public int School_ID { get; set; }
        public string SchoolName { get; set; }

        public ICollection<Juvenile> Juveniles { get; set; }
    }
}
