using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JiraComunicacao.Model
{
    public class JiraDescriptionDTO
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("version")]
        public int Version { get; set; }
        
        [JsonPropertyName("content")]
        public List<JiraContentDTO> Content { get; set; }

    }
}
