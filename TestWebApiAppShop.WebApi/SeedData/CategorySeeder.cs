using TestWebApiAppShop.Domain.Entity;

namespace TestWebApiAppShop.WebApi.SeedData
{
    public class CategorySeeder
    {
        public static List<Category> CategoriesSeed =
            [
                new Category { Name = "Electronics", Description = "Electronic devices" },
                new Category { Name = "Books", Description = "Books and literature" }
            ];
    }
}
