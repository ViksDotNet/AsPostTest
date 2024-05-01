using AsposeTest.Interfaces;
using Hangfire;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AsposeTest.Classes
{
    public class EnqueueService : IEnqueueService
    {
        private readonly IBackgroundJobClient _backgroundJobs;

        private readonly ILogger<EnqueueService> _logger;

        private readonly IRenderService _renderService;



        public EnqueueService(IBackgroundJobClient backgroundJobs, ILogger<EnqueueService> logger, IRenderService renderService)
        {
            _backgroundJobs = backgroundJobs;
            _logger = logger;
            _renderService = renderService;

        }

        public string EnqueueZavacorReportRequest()
        {
            var uniqueId = _backgroundJobs.Schedule<IRenderService>(x => x.ProcessZavacorReportRequest(), TimeSpan.FromSeconds(5));
            _logger.LogInformation($"Request with ZCReportCode  has been queued with Job Id - {uniqueId}");
            return uniqueId;          
        }
    }
}
