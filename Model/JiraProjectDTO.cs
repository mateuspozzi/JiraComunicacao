using System.Text.Json.Serialization;

namespace JiraComunicacao.Model
{
    public class JiraProjectDTO
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
