using Microsoft.EntityFrameworkCore;
using TestWebApiAppShop.Application.Client.Interfaces;
using TestWebApiAppShop.Application.Client.Services;
using TestWebApiAppShop.Application.Purchase.Interfaces;
using TestWebApiAppShop.Application.Purchase.Services;
using TestWebApiAppShop.Infrastructure.Db;
using TestWebApiAppShop.WebApi.SeedData;

namespace TestWebApiAppShop.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            string connStr = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseSqlServer(connStr);
            });

            builder.Services.AddScoped<IClientServices, ClientServices>();
            builder.Services.AddScoped<IPurchaseService, PurchaseService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
                dbContext.Database.EnsureCreated();

                if (!dbContext.Clients.Any())
                {
                    dbContext.Clients.AddRange(ClientSeeder.SeedClients);
                    dbContext.SaveChanges();
                }
            }

            app.Run();
        }
    }
}
