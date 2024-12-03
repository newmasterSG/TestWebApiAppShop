using TestWebApiAppShop.Domain.Entity;

namespace TestWebApiAppShop.WebApi.SeedData
{
    public class ProductSeeder
    {
        public static List<Product> SeedProduct = new()
        {
                new Product { Name = "Laptop", Price = 1000, Category = CategorySeeder.CategoriesSeed[0], Article = "A100" },
                new Product { Name = "Smartphone", Price = 500, Category = CategorySeeder.CategoriesSeed[0], Article = "A101" },
                new Product { Name = "Programming Book", Price = 30, Category = CategorySeeder.CategoriesSeed[1], Article = "B100" }
            };
    }
}
