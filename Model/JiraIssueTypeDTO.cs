using System.Text.Json.Serialization;

namespace JiraComunicacao.Model
{
    public class JiraIssueTypeDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
