using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JiraComunicacao.Model.GetStatusCard
{
    public class JiraStatusCardFieldDTO
    {
        [JsonPropertyName("status")]
        public JiraStatusCardStatusDTO Status { get; set; }
    }
}
