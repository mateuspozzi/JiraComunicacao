using JiraComunicacao.Model;
using JiraComunicacao.Model.GetStatusCard;
using JiraComunicacao.Model.Request;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JiraComunicacao.Controllers
{
    [ApiController]
    [Route("jira")]
    public class JiraController : Controller
    {
        [HttpPost]
        public JiraResultadoCriacaoCardDTO RegistrarCard([FromBody] JiraCardRequest campos)
        {
            var client = new RestClient("https://projeto-teste-teste.atlassian.net/rest/api/3/issue");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //Criptografar em Base64 encode o email usuario e token ex: teste@teste.com:token gerado no site do Jira 
            //onde gera o token
            //https://id.atlassian.com/manage-profile/security/api-tokens
            request.AddHeader("Authorization", "Basic tokenGerado");
            request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Cookie", "atlassian.xsrf.token=2c1598cd-3610-4bd9-bd43-26bcf448b770_42e9323f5c442620b3e09f372cd874aa0dd6b359_lin");

            JiraDTO card = new JiraDTO
            {
                Fields = new JiraFieldsDTO
                {
                    Project = new JiraProjectDTO { Key = "MOD" },
                    Summary = campos.Titulo,

                    Description = new JiraDescriptionDTO
                    {
                        Type = "doc",
                        Version = 1,
                        Content = new List<JiraContentDTO>{ new JiraContentDTO {
                            Type = "paragraph",
                            Content = new List<JiraContentDTO>{ new JiraContentDTO { Type = "text", Text = campos.Descricao } }
                        }},
                    },

                    IssueType = new JiraIssueTypeDTO { Id = 10006 }
                }
            };

            string json = JsonSerializer.Serialize(card, new JsonSerializerOptions { IgnoreNullValues = true });

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return JsonSerializer.Deserialize<JiraResultadoCriacaoCardDTO>(response.Content);
        }

        [HttpGet]
        public IActionResult ObterStatusCardJira(string chaveOuId)
        {
            var client = new RestClient($"https://projeto-teste-teste.atlassian.net/rest/api/3/issue/{chaveOuId}?fields=status");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic tokenGerado");
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JiraStatusCardDTO retorno = JsonSerializer.Deserialize<JiraStatusCardDTO>(response.Content);
                return Ok(retorno?.Fields?.Status?.Name);

            }
            else
                return NotFound(response.Content);
        }
    }
}
