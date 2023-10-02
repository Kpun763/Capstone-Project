using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public AnimeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            // Configure the HTTP client with the base URL of the anime API and any necessary headers.
            _httpClient.BaseAddress = new Uri("https://api.example.com/anime/");
            // Add headers if required for authentication or other purposes.
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAnime([FromQuery] string query)
        {
            try
            {
                // Make a request to the external anime API to search for anime based on the query.
                var response = await _httpClient.GetAsync($"search?query={query}");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response and map it to your application's models or DTOs.
                    var animeData = await response.Content.ReadAsAsync<AnimeSearchResult>();

                    // Process the data as needed and return it as JSON.
                    return Ok(animeData);
                }
                else
                {
                    // Handle API errors and return an appropriate response.
                    return StatusCode((int)response.StatusCode, "Error from external API");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}