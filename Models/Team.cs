using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace sportLeague.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Team Name is required.")]
        [StringLength(100, ErrorMessage = "Team Name cannot exceed 100 characters.")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        public string? City { get; set; }


        [Required(ErrorMessage = "Year Established is required.")]
        [Range(1900, int.MaxValue, ErrorMessage = "Year Established must be a valid year.")]
        public int YearEstablished { get; set; }

        [ForeignKey("League")]
        [Required(ErrorMessage = "League is required.")]
        public int LeagueId { get; set; }
        public League? League { get; set; } 

        public ICollection<Player> Players { get; set; } = new List<Player>();

    }

}
