using Microsoft.AspNetCore.Mvc;
using SVTRoboticsAPI.Models;

namespace SVTRoboticsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotsController : ControllerBase
    {
        private static string ROBOTS_API_ENDPOINT = "https://60c8ed887dafc90017ffbd56.mockapi.io/robots";
        private readonly ILogger<RobotsController> _logger;

        public RobotsController(ILogger<RobotsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/api/robots/closest")]
        public async Task<JsonResult> GetClosest()
        {
            HttpClient http = new HttpClient();
            var response = await http.GetAsync(ROBOTS_API_ENDPOINT);
            if (!response.IsSuccessStatusCode)
            {
                return new JsonResult("{ \"success\": false,  \"error\": \"The /robots API endpoint is unreachable.\" }");
            }
            string test = await response.Content.ReadAsStringAsync();
            List<Robot> robots = await response.Content.ReadFromJsonAsync<List<Robot>>();
            return new JsonResult(robots);
        }
    }
}