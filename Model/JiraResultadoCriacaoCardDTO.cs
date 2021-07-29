using System.Text.Json.Serialization;

namespace JiraComunicacao.Model
{
    public class JiraResultadoCriacaoCardDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
