using Microsoft.AspNetCore.Mvc;
using SVTRoboticsAPI.Models;
using SVTRoboticsAPI.Utilities;
using System.Text.Json;

namespace SVTRoboticsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotsController : ControllerBase
    {
        private static string ROBOTS_API_ENDPOINT = "https://60c8ed887dafc90017ffbd56.mockapi.io/robots";
        private readonly ILogger<RobotsController> _logger;
        private readonly RobotUtilities _utilities;

        public RobotsController(ILogger<RobotsController> logger)
        {
            _logger = logger;
            _utilities = new RobotUtilities();
        }

        [HttpPost("/api/robots/closest")]
        public async Task<JsonResult> GetClosest([FromBody] JsonElement bodyJson)
        {
            HttpClient http = new HttpClient();
            var response = await http.GetAsync(ROBOTS_API_ENDPOINT);
            if (!response.IsSuccessStatusCode)
            {
                return new JsonResult("{ \"success\": false,  \"error\": \"The /robots API endpoint is unreachable.\" }");
            }
            string test = await response.Content.ReadAsStringAsync();
            List<Robot>? robots = await response.Content.ReadFromJsonAsync<List<Robot>>();
            if (robots == null)
            {
                return new JsonResult("{ \"success\": false,  \"error\": \"The /robots API endpoint returned no data.\" }");
            }
            ChosenRobot chosenRobot = _utilities.ChooseRobot(robots,
                bodyJson.GetProperty("loadId").ToString(),
                bodyJson.GetProperty("x").GetInt32(),
                bodyJson.GetProperty("y").GetInt32());
            return new JsonResult(chosenRobot);
        }
    }
}