using MeasurementService.Core;
using MeasurementService.Models;
using MeasurementService.Units;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MeasurementService.Controllers
{
    [ApiController]
    [Route("api/measurement")]
    public class MeasurementController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public MeasurementController(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        // POST /api/measurement/convert/{toUnit}
        // Body: { "value": 1, "unit": "FEET", "enumIndex": 1 }
        [HttpPost("convert/{toUnit}")]
        public async Task<IActionResult> Convert([FromBody] QuantityDTO dto, [FromRoute] string toUnit)
        {
            try
            {
                Enum unit = ParseUnit(dto.EnumIndex, dto.Unit);
                Enum target = ParseUnit(dto.EnumIndex, toUnit.ToUpper());

                var quantity = new Quantity(dto.Value, unit);
                var result = quantity.ConvertTo(target);

                string userId = GetUserId();
                await SaveHistory(userId, dto, null, result);

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ArithmeticDTO dto, [FromQuery] string toUnit)
        {
            try
            {
                ValidateSameType(dto.Quantity1.EnumIndex, dto.Quantity2.EnumIndex);

                Enum u1 = ParseUnit(dto.Quantity1.EnumIndex, dto.Quantity1.Unit);
                Enum u2 = ParseUnit(dto.Quantity2.EnumIndex, dto.Quantity2.Unit);
                Enum target = ParseUnit(dto.Quantity1.EnumIndex, toUnit.ToUpper());

                var q1 = new Quantity(dto.Quantity1.Value, u1);
                var q2 = new Quantity(dto.Quantity2.Value, u2);
                var result = q1.Add(q2, target);

                string userId = GetUserId();
                await SaveHistory(userId, dto.Quantity1, dto.Quantity2, result);

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("subtract")]
        public async Task<IActionResult> Subtract([FromBody] ArithmeticDTO dto, [FromQuery] string toUnit)
        {
            try
            {
                ValidateSameType(dto.Quantity1.EnumIndex, dto.Quantity2.EnumIndex);

                Enum u1 = ParseUnit(dto.Quantity1.EnumIndex, dto.Quantity1.Unit);
                Enum u2 = ParseUnit(dto.Quantity2.EnumIndex, dto.Quantity2.Unit);
                Enum target = ParseUnit(dto.Quantity1.EnumIndex, toUnit.ToUpper());

                var q1 = new Quantity(dto.Quantity1.Value, u1);
                var q2 = new Quantity(dto.Quantity2.Value, u2);
                var result = q1.Subtract(q2, target);

                string userId = GetUserId();
                await SaveHistory(userId, dto.Quantity1, dto.Quantity2, result);

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("divide")]
        public async Task<IActionResult> Divide([FromBody] ArithmeticDTO dto, [FromQuery] string toUnit)
        {
            try
            {
                ValidateSameType(dto.Quantity1.EnumIndex, dto.Quantity2.EnumIndex);

                Enum u1 = ParseUnit(dto.Quantity1.EnumIndex, dto.Quantity1.Unit);
                Enum u2 = ParseUnit(dto.Quantity2.EnumIndex, dto.Quantity2.Unit);
                Enum target = ParseUnit(dto.Quantity1.EnumIndex, toUnit.ToUpper());

                var q1 = new Quantity(dto.Quantity1.Value, u1);
                var q2 = new Quantity(dto.Quantity2.Value, u2);
                var result = q1.Divide(q2, target);

                string userId = GetUserId();
                await SaveHistory(userId, dto.Quantity1, dto.Quantity2, result);

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("equals")]
        public IActionResult CheckEquality([FromBody] ArithmeticDTO dto)
        {
            try
            {
                Enum u1 = ParseUnit(dto.Quantity1.EnumIndex, dto.Quantity1.Unit);
                Enum u2 = ParseUnit(dto.Quantity2.EnumIndex, dto.Quantity2.Unit);

                var q1 = new Quantity(dto.Quantity1.Value, u1);
                var q2 = new Quantity(dto.Quantity2.Value, u2);
                bool isEqual = q1.IsEqualTo(q2);

                return Ok(new { success = true, data = new { isEqual } });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        // Helper method
        private static Enum ParseUnit(int enumIndex, string unitName)
        {
            return enumIndex switch
            {
                1 => (Enum)Enum.Parse(typeof(LengthUnit), unitName),
                2 => (Enum)Enum.Parse(typeof(WeightUnit), unitName),
                3 => (Enum)Enum.Parse(typeof(VolumeUnit), unitName),
                4 => (Enum)Enum.Parse(typeof(TemperatureUnit), unitName),
                _ => throw new ArgumentException($"Invalid EnumIndex: {enumIndex}. Use 1=Length, 2=Weight, 3=Volume, 4=Temperature")
            };
        }

        
        private static void ValidateSameType(int idx1, int idx2)
        {
            if (idx1 != idx2)
                throw new ArgumentException("Both quantities must be of the same unit type.");
        }

        private string GetUserId()
        {
            return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
        }

        private async Task SaveHistory(string userId, QuantityDTO q1, QuantityDTO? q2, ResultDTO result)
        {
            if (string.IsNullOrEmpty(userId)) return; 

            var payload = new HistoryPayloadDTO
            {
                UserId = userId,
                InputValue1 = q1.Value,
                InputUnit1 = q1.Unit,
                InputValue2 = q2?.Value,
                InputUnit2 = q2?.Unit,
                TargetUnit = result.ResultUnit,
                Operation = result.Operation,
                ResultValue = result.ResultValue,
                ResultUnit = result.ResultUnit
            };

            try
            {
                var client = _httpClientFactory.CreateClient();
                var historyUrl = _config["Services:HistoryService"] + "/api/history";

                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PostAsync(historyUrl, content);
            }
            catch
            {

            }
        }
    }
}
