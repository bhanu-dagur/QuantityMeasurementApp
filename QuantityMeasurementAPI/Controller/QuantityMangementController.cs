using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTO;
using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppBusinessLayer.Interface;


namespace QuantityMeasurementAPI.Controller;

[Route("api/")]
[ApiController]
public class QuantityMangementController : ControllerBase
{
    private readonly IMeasurementService _measurementService;
    public QuantityMangementController(IMeasurementService measurementService)
    {
        this._measurementService = measurementService;
    }
    [HttpPost("Conversion/{toUnit}")]
     public IActionResult QuantityMeasurementConversion([FromBody]  QuantityDTO newProduct,[FromRoute] string toUnit)
    {
        QuantityDTO result = _measurementService.PerformConversion(newProduct, toUnit.ToUpper());
        return Ok(new
        {
            resultValue=result.Value,
            resultUnit=result.Unit  
        });
    }

    [HttpPost("addition")]
    public IActionResult QuantityMeasurementAddition([FromBody]  AirthmeticDTO newEntity,[FromQuery] string toUnit)
    {
        var result = _measurementService.PerformAddition(newEntity.Quantity1, newEntity.Quantity2, toUnit.ToUpper());
        return Ok(new
        {
            resultValue = result.Value,
            resultUnit = result.Unit
        });
        
    }

    [HttpPost("Subtraction")]
    public IActionResult QuantityMeasurementSubtraction([FromBody] AirthmeticDTO newEntity, [FromQuery] string toUnit)
    {
        var result = _measurementService.PerformSubtraction(newEntity.Quantity1, newEntity.Quantity2, toUnit.ToUpper());
        return Ok(new
        {
            resultValue = result.Value,
            resultUnit =  result.Unit 
        });
    }

    [HttpPost ("CheckEquaity")]
    public IActionResult CheckEquaity([FromBody] AirthmeticDTO newEntity)
    {
        var result = _measurementService.CheckEquality(newEntity.Quantity1, newEntity.Quantity2);
        return Ok(result);
    }


    
    
    
}