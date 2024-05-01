using AsposeTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsposeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IEnqueueService _enqueueService; 

        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(IEnqueueService enqueueService,ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _enqueueService = enqueueService;
        }

      
        [HttpPost]
        [Route("/api/enqueue/PostMessagesFromZavacor")] 
        [ProducesResponseType(typeof(string), 503)]    
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<ActionResult> PostMessagesFromZavacorAsync([FromBody] string test)
        {                          
            try
            {
                var jobId = await TranslateDataToSaveInFile();
                           
                return Ok();
            }
            catch (Exception e)
            {
                           
                return StatusCode(503, "Service is unavailable");
            }
                  
        }
        private  Task<string> TranslateDataToSaveInFile()
        {
            // Process the request to generate html files             
            var jobId =  _enqueueService.EnqueueZavacorReportRequest(); 
            return Task.FromResult(jobId);
        }
    }
}
