using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sportLeague.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Player Name is required.")]
        [StringLength(50, ErrorMessage = "Player Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Player Name is required.")]
        [StringLength(50, ErrorMessage = "Player Name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [StringLength(30)]
        public string Position { get; set; }

        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99.")]
        public int Age { get; set; }


        [ForeignKey("Team")]
        [Required(ErrorMessage = "Team is required.")]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }

}
