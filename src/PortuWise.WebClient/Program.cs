using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortuWise.WebClient.ApiServices;

namespace PortuWise.WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp =>
            {
                var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7230/") };
                return httpClient;
            });

            builder.Services.AddScoped<ICategoryApiService, CategoryApiService>();
            builder.Services.AddScoped<ILessonApiService, LessonApiService>();
            builder.Services.AddScoped<IWordsApiService, WordsApiService>();

            await builder.Build().RunAsync();
        }
    }
}
