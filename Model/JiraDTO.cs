using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JiraComunicacao.Model
{
    public class JiraDTO
    {
        [JsonPropertyName("fields")]
        public JiraFieldsDTO Fields { get; set; }
    }
}
