using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebAPI_Marjorie_Falcone__20240904.Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }

        // Foreign key
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation properties
        [NotMapped]
        public ICollection<Comment> Comments { get; set; }
        [NotMapped]
        public ICollection<Notification> Notifications { get; set; }

        public Post()
        {
            Comments = new HashSet<Comment>();
            Notifications = new HashSet<Notification>();
        }
    }
}
