using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProxyController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("graphql")]
        public async Task<IActionResult> ProxyGraphQL([FromBody] object query)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/graphql/")
            {
                Content = new StringContent(query.ToString(), System.Text.Encoding.UTF8, "application/json")
            };

            // Send request to the actual GraphQL server
            var response = await _httpClient.SendAsync(requestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            // Forward the response back to the frontend
            return Content(responseBody, "application/json");
        }
    }
}
