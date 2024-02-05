using AWS.Core.Contracts;
using System.Text.Json.Serialization;

namespace Aws.Core.AdaptersDriven
{
    public class NotificationMsg : IMessage
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("order-number")]
        public string? Notification { get; set; }

        [JsonIgnore]
        public string MessageTypeName => nameof(NotificationMsg);


    }
}
