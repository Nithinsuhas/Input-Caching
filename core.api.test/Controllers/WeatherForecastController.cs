using InputCaching.net.framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelectPdf;

namespace core.api.test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            var path = @"C:\Users\MM10041364\Desktop\lal.html";

            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(path);


            var id = new Guid().ToString() + ".pdf";
            // save pdf document
            doc.Save(@"C:\Users\MM10041364\Desktop\pdf\" + id);
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        [HttpPost]
        public IActionResult Post(Data model)
        {
            /* model must implement IMemoryObject Or Inherit from MemoryObject */
            var Collection = MemoryCache.Collection;
            if (Collection.Push(model))
            {
               return Ok("Added");
            }
            else
            {
                return BadRequest("Already Added");
            }
        }

       public class Data:MemoryObject
        {
            public int Id { get; set; }
            public string Code { get; set; }
        }
    }
}
