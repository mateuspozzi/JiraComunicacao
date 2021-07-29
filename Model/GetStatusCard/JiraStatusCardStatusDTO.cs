using System.Text.Json.Serialization;

namespace JiraComunicacao.Model.GetStatusCard
{
    public class JiraStatusCardStatusDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
