using System.Text.Json.Serialization;

namespace NotificationGateway.Model.DTOs
{
    public class SendPushRequest
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = string.Empty;

        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; } = string.Empty;

        [JsonPropertyName("template_data")]
        public Dictionary<string, string> TemplateData { get; set; } = new();
    }
}
