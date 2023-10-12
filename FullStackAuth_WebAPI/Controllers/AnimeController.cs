using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[anime]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private static readonly string MyAnimeListApiKey = "4c9b309b7dc9dc87f29fbf259084aac5";

        [HttpGet]
        public async Task<IActionResult> GetAnimeInfo(string search)
        {
            using (var client = new HttpClient())
            {
                // Set your API key in the request headers
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {MyAnimeListApiKey}");

                // Define your request URI based on the MyAnimeList API documentation
                var requestUri = new Uri($"https://api.myanimelist.net/v2/anime?query={search}");

                try
                {
                    using (var response = await client.GetAsync(requestUri))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();

                        // You can now process the responseBody as needed
                        return Ok(responseBody);
                    }
                }
                catch (HttpRequestException)
                {
                    return StatusCode(500, "An error occurred when making the request to MyAnimeList API.");
                }
            }
        }
    }
}
