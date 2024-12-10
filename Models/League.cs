using System.ComponentModel.DataAnnotations;
using sportLeague.Models;

namespace sportLeague.Models
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }

        [Required(ErrorMessage = "League Name is required.")]
        [StringLength(50, ErrorMessage = "League Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string Country { get; set; }

        [StringLength(50)]
        public string SportType { get; set; }

        [Required(ErrorMessage = "Established Year is required.")]
        [Range(1900, int.MaxValue, ErrorMessage = "Established Year must be a valid year.")]
        public int YearFounded { get; set; }

        public ICollection<Team> Teams { get; set; }
    }

}
