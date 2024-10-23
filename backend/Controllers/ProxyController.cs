using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/proxy")]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ProxyController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("graphql")]
    public async Task<IActionResult> PostGraphQL([FromBody] object query)
    {
        var response = await _httpClient.PostAsJsonAsync("http://172.20.61.38:5000/graphql", query);
        return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
    }
}
