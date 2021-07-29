using System.Text.Json.Serialization;

namespace JiraComunicacao.Model.GetStatusCard
{
    public class JiraStatusCardDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("self")]
        public string Self { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("fields")]
        public JiraStatusCardFieldDTO Fields { get; set; }
    }
}
