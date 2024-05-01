using AsposeTest.Interfaces;
using Hangfire.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsposeTest.Classes
{
    public class RenderService : IRenderService
    {
        private readonly HttpClient _httpClient;    

        private readonly ILogger<RenderService> _logger;
        private IMemoryCache _cache;
        private bool disposedValue;
        private readonly IDataTranslatorFileStorage _dataTranslatorFileStorage;
        public RenderService(
           IDataTranslatorFileStorage dataTranslatorFileStorage,
           HttpClient httpClient, ILogger<RenderService> logger,
           IMemoryCache memoryCache)
        {
            
            _dataTranslatorFileStorage = dataTranslatorFileStorage;
            _httpClient = httpClient;
            _logger = logger;
            _cache = memoryCache;
        }
        public async Task ProcessZavacorReportRequest()
        {
            // Save PDF File
             //var htmlResponse = await _dataTranslatorFileStorage.SavePDFFile("Test");


            byte[] bytes = new byte[100000000];
            Random rand = new Random();
            rand.NextBytes(bytes);

            _logger.LogInformation("Did it **********");
        }
    }

}
