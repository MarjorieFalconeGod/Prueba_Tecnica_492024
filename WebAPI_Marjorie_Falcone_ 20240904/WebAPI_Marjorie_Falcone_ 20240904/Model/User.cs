using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebAPI_Marjorie_Falcone__20240904.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Navigation properties
        [NotMapped]
        public ICollection<Post> Posts { get; set; }
        [NotMapped]
        public ICollection<Comment> Comments { get; set; }
        [NotMapped]
        public ICollection<Follower> Followers { get; set; }
        [NotMapped]
        public ICollection<Notification> Notifications { get; set; }

        public User()
        {
            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
            Followers = new HashSet<Follower>();
            Notifications = new HashSet<Notification>();
        }
    }
}
