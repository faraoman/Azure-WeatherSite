using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherSite.DB
{
    public class WeatherDBContext : DbContext
    {
        public DbSet<tblWeatherForecast> tblWeatherForecast { get; set; }

        public WeatherDBContext() : base(){}
        public WeatherDBContext(DbContextOptions<WeatherDBContext> options) : base(options) { }
    }
}
