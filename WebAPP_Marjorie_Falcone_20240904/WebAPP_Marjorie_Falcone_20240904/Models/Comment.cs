using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPP_Marjorie_Falcone_20240904.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        // Navigation properties
        [NotMapped]
        public ICollection<Notification> Notifications { get; set; }

        public Comment()
        {
            Notifications = new HashSet<Notification>();
        }
    }
}
