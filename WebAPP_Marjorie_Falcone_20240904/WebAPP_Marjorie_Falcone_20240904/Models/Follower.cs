using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPP_Marjorie_Falcone_20240904.Models
{
    public class Follower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FollowerId { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
