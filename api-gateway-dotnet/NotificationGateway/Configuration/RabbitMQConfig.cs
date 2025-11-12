namespace NotificationGateway.Configuration
{
    public class RabbitMQConfig
    {
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 5672;
        public string Username { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string VirtualHost { get; set; } = "/";

        // Queue names
        public string EmailQueue { get; set; } = "email.queue";
        public string PushQueue { get; set; } = "push.queue";
        public string FailedQueue { get; set; } = "failed.queue";
        public string ExchangeName { get; set; } = "notifications.direct";
    }
}
