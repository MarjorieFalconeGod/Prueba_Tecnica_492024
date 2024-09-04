using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Marjorie_Falcone__20240904.Model
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
