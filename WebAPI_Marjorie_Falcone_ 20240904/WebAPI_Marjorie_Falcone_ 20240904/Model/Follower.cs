using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Marjorie_Falcone__20240904.Model
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
