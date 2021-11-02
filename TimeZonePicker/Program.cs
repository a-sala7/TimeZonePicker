using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TimeZonePicker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            var tzAndCountryInfo = new TzAndCountryInfo();
            tzAndCountryInfo.Countries = await http.GetFromJsonAsync<IEnumerable<CountryItem>>("/json/countries.json");
            tzAndCountryInfo.TimeZones = await http.GetFromJsonAsync<IEnumerable<TimeZoneItem>>("/json/zones.json");
            builder.Services.AddSingleton<TzAndCountryInfo>(tzAndCountryInfo);

            await builder.Build().RunAsync();
        }
    }
}
