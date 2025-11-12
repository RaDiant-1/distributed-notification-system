using System.Text.Json.Serialization;

namespace NotificationGateway.Model.DTOs
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("error")]
        public string? Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("meta")]
        public PaginationMeta? Meta { get; set; }

    }
}
