using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortuWise.DataAccess;

namespace PortuWise.Infrastructure.DbSeeder
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.AddDbContext<PortuWiseDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            var provider = services.BuildServiceProvider();
            
            using (var db = provider.GetRequiredService<PortuWiseDbContext>())
            {
                var categoriesSeeder = new SeedCategories(db);
                var wordsSeeder = new SeedWords(db);
                var phrasesSeeder = new SeedPhrases(db);
                var lessonsSeeder = new SeedLessons(db);

                //await wordsSeeder.Seed();

                //await categoriesSeeder.Seed();
                await phrasesSeeder.Seed();
                //await phrasesSeeder.Seed();
                //await lessonsSeeder.Seed();
            }
        }
    }
}
