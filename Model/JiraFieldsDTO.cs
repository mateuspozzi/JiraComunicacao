using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JiraComunicacao.Model
{
    
    public class JiraFieldsDTO
    {
        [JsonPropertyName("project")]
        public JiraProjectDTO Project { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("description")]
        public JiraDescriptionDTO Description { get; set; }

        [JsonPropertyName("issuetype")]
        public JiraIssueTypeDTO IssueType { get; set; }
    }
}
