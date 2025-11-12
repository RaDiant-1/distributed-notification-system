using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationGateway.Model.Enums;

namespace NotificationGateway.Model.Entities
{
    [Table("notifications")]
    public class Notification
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("type")]
        public NotificationType Type { get; set; }

        [Column("recipient")]
        public string Recipient { get; set; } = string.Empty;

        [Column("subject")]
        public string? Subject { get; set; }

        [Column("message")]
        public string Message { get; set; } = string.Empty;

        [Column("status")]
        public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

        [Column("request_id")]
        public string RequestId { get; set; } = string.Empty;

        [Column("user_id")]
        public string UserId { get; set; } = string.Empty;

        [Column("template_id")]
        public string? TemplateId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("sent_at")]
        public DateTime? SentAt { get; set; }

        [Column("error_message")]
        public string? ErrorMessage { get; set; }

    }
}
