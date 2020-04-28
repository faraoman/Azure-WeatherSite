using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WeatherSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // QAD aka Quick And Dirty
        private readonly ILogger<WeatherForecastController> _logger;
        DbContextOptionsBuilder<DB.WeatherDBContext> _optionsBuilder;
        IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _optionsBuilder = new DbContextOptionsBuilder<DB.WeatherDBContext>();
            var sqlConnectionString = configuration.GetConnectionString("AzureSqlDatabase");
            _optionsBuilder.UseSqlServer(sqlConnectionString);
        }

        [HttpGet]
        public async Task<IEnumerable<tblWeatherForecast>> Get()
        {
            { // Writing data to log
                var remoteInfo = HttpContext.Request.HttpContext.Connection;
                var strToLog = $"{remoteInfo.RemoteIpAddress}:{remoteInfo.RemotePort}\t[GET]\tWeatherForecast\r\n";
                var storageConnectionString = _configuration.GetConnectionString("AzureStorage");
                var containerName = "weathersitelogcontainer";
                var fileName = "log.txt";
                {
                    var storageAccount = Cloud.IO.Storage.GetStorageAccount(storageConnectionString);
                    if (storageAccount != null)
                    {
                        var client = storageAccount.CreateCloudBlobClient();
                        var container = client.GetContainerReference(containerName);
                        await container.CreateIfNotExistsAsync();
                        var file = container.GetAppendBlobReference(fileName);
                        if (await file.ExistsAsync())
                        { // append
                            await file.AppendTextAsync(strToLog);
                        }
                        else
                        { // create
                            file.Properties.ContentType = "text/plain";
                            await file.UploadTextAsync(strToLog);
                        }
                    }
                }
            }

            // load data from Azure SQL Database
            List<tblWeatherForecast> result = null;
            using (var db = new DB.WeatherDBContext(_optionsBuilder.Options))
            {
                result = db.tblWeatherForecast.ToList();
            }

            return result;
        }
    }
}
