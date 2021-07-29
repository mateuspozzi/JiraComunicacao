using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JiraComunicacao.Model
{
    public class JiraContentDTO
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("content")]
        public List<JiraContentDTO> Content { get; set; }
    }
}
