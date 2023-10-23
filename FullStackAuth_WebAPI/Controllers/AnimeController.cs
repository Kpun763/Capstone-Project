using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/proxy")]
    [EnableCors("ReactPolicy")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        [HttpGet("anime/search")]
        public async Task<IActionResult> SearchAnime(string searchTerm)
        {
            using (var client = new HttpClient())
            {
                var requestUri = new Uri($"https://api.myanimelist.net/v2/anime?q={searchTerm}&limit=20");
                client.DefaultRequestHeaders.Add("X-MAL-CLIENT-ID", "4c9b309b7dc9dc87f29fbf259084aac5");

                try
                {
                    using (var response = await client.GetAsync(requestUri))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();

                        var animeResponse = JsonConvert.DeserializeObject<AnimeResponse>(responseBody);

                        return Ok(animeResponse);
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
