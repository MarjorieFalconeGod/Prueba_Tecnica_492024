using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPP_Marjorie_Falcone_20240904.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }
        public string Text { get; set; }
        public DateTime DateSent { get; set; }

        // Foreign key
        public int UserId { get; set; }
        public User User { get; set; }

        public int? RelatedPostId { get; set; }
        public Post RelatedPost { get; set; }

        public int? RelatedCommentId { get; set; }
        public Comment RelatedComment { get; set; }
    }
}
