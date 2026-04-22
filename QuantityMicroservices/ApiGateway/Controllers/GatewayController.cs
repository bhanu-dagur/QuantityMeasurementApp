/*


======================= Not YET USED IN THIS PROJECT =========================

using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiGateway.Controllers
{
    // ============================
    // API Gateway - S
    //
    // Client sirf 5000 port pe request karta hai.
    // Gateway us request ko sahi service pe forward karta hai.
    //
    //  Client
    //    |
    //    v
    // ApiGateway :5000
    //    |         |         |
    //    v         v         v
    // Auth:5001  Meas:5002  Hist:5003

    [ApiController]
    [Route("gateway")]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        public GatewayController(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }

        // ============================
        // AUTH ROUTES
        // POST gateway/auth/register  → AuthService
        // POST gateway/auth/login     → AuthService
        // ============================

        [HttpPost("auth/register")]
        public async Task<IActionResult> Register([FromBody] Object dto)
        {
            return await Forward(_config["Services:AuthService"] + "/api/auth/register");
        }

        [HttpPost("auth/login")]
        public async Task<IActionResult> Login()
        {
            return await Forward(_config["Services:AuthService"] + "/api/auth/login");
        }

        // ============================
        // MEASUREMENT ROUTES
        // POST gateway/measurement/convert/{toUnit}  → MeasurementService
        // POST gateway/measurement/add               → MeasurementService
        // POST gateway/measurement/subtract          → MeasurementService
        // POST gateway/measurement/divide            → MeasurementService
        // POST gateway/measurement/equals            → MeasurementService
        // ============================

        [HttpPost("measurement/convert/{toUnit}")]
        public async Task<IActionResult> Convert(string toUnit)
        {
            return await Forward(
                _config["Services:MeasurementService"] + $"/api/measurement/convert/{toUnit}",
                forwardAuth: true);
        }

        [HttpPost("measurement/add")]
        public async Task<IActionResult> Add([FromQuery] string toUnit)
        {
            return await Forward(
                _config["Services:MeasurementService"] + $"/api/measurement/add?toUnit={toUnit}",
                forwardAuth: true);
        }

        [HttpPost("measurement/subtract")]
        public async Task<IActionResult> Subtract([FromQuery] string toUnit)
        {
            return await Forward(
                _config["Services:MeasurementService"] + $"/api/measurement/subtract?toUnit={toUnit}",
                forwardAuth: true);
        }

        [HttpPost("measurement/divide")]
        public async Task<IActionResult> Divide([FromQuery] string toUnit)
        {
            return await Forward(
                _config["Services:MeasurementService"] + $"/api/measurement/divide?toUnit={toUnit}",
                forwardAuth: true);
        }

        [HttpPost("measurement/equals")]
        public async Task<IActionResult> Equals()
        {
            return await Forward(
                _config["Services:MeasurementService"] + "/api/measurement/equals",
                forwardAuth: true);
        }

        // HISTORY ROUTES
        // GET gateway/history/mine  → HistoryService

        [HttpGet("history/mine")]
        public async Task<IActionResult> GetMyHistory()
        {
            return await ForwardGet(
                _config["Services:HistoryService"] + "/api/history/mine",
                forwardAuth: true);
        }

        // HEALTH CHECK

        [HttpGet("health")]
        public async Task<IActionResult> Health()
        {
            var client = _factory.CreateClient();
            var results = new Dictionary<string, string>();

            var services = new Dictionary<string, string>
            {
                { "AuthService",        _config["Services:AuthService"]        + "/api/auth/health" },
                { "MeasurementService", _config["Services:MeasurementService"] + "/swagger/index.html" },
                { "HistoryService",     _config["Services:HistoryService"]     + "/swagger/index.html" }
            };

            foreach (var (name, url) in services)
            {
                try
                {
                    var res = await client.GetAsync(url);
                    results[name] = res.IsSuccessStatusCode ? "UP" : "DOWN";
                }
                catch
                {
                    results[name] = "DOWN";
                }
            }

            return Ok(new { gateway = "UP", services = results });
        }

        // HELPER - POST request forward karo
        private async Task<IActionResult> Forward(string url, bool forwardAuth = false)
        {
            var client = _factory.CreateClient();

            // Authorization (JWT token) forward
            if (forwardAuth)
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(authHeader))
                    client.DefaultRequestHeaders.Authorization =
                        AuthenticationHeaderValue.Parse(authHeader);
            }

            Request.EnableBuffering();

            using var reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true);
            string body = await reader.ReadToEndAsync();

            Request.Body.Position = 0;
        
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            string responseBody = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode,
                JsonSerializer.Deserialize<object>(responseBody));
        }

        // HELPER - GET request forward karo
        private async Task<IActionResult> ForwardGet(string url, bool forwardAuth = false)
        {
            var client = _factory.CreateClient();

            if (forwardAuth)
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(authHeader))
                    client.DefaultRequestHeaders.Authorization =
                        AuthenticationHeaderValue.Parse(authHeader);
            }

            var response = await client.GetAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode,
                JsonSerializer.Deserialize<object>(responseBody));
        }
    }
}


*/
