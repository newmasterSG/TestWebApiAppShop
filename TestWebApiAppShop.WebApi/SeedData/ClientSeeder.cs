using TestWebApiAppShop.Domain.Entity;

namespace TestWebApiAppShop.WebApi.SeedData
{
    public class ClientSeeder
    {
        static ClientSeeder()
        {
            foreach (var client in SeedClients)
            {
                foreach (var purchase in client.Purchases)
                {
                    purchase.TotalCost = purchase.PurchaseItems.Sum(item => item.Product.Price * item.Quantity);
                }
            }
        }

        public static List<Client> SeedClients = new List<Client>
            {
                new Client
                {
                    FirstName = "John",
                    MiddleName = "Doe",
                    LastName = "Smith",
                    BirthDate = new DateTime(1990, 12, 3),
                    RegistrationDate = DateTime.UtcNow.AddYears(-2),
                    Purchases = new List<Purchase>
                    {
                        new Purchase
                        {
                            OrderNumber = "ORD12245",
                            Date = DateTime.UtcNow.AddDays(-2),
                            PurchaseItems = new List<PurchaseItem>
                            {
                                new PurchaseItem { Product = ProductSeeder.SeedProduct[0], Quantity = 1,},
                                new PurchaseItem { Product = ProductSeeder.SeedProduct[2], Quantity = 2 }
                            },
                        },
                        new Purchase
                        {
                            OrderNumber = "ORD12345",
                            Date = DateTime.UtcNow.AddDays(-5),
                            PurchaseItems = new List<PurchaseItem>
                            {
                                new PurchaseItem { Product = ProductSeeder.SeedProduct[1], Quantity = 1 }
                            }
                        }
                    }
                },
                new Client
                {
                    FirstName = "Jane",
                    MiddleName = "Ann",
                    LastName = "Doe",
                    BirthDate = new DateTime(1985, 12, 3),
                    RegistrationDate = DateTime.UtcNow.AddYears(-1),
                    Purchases = new List<Purchase>
                    {
                        new Purchase
                        {
                            OrderNumber = "OAD12345",
                            Date = DateTime.UtcNow.AddDays(-1),
                            PurchaseItems = new List<PurchaseItem>
                            {
                                new PurchaseItem { Product = ProductSeeder.SeedProduct[1], Quantity = 3 }
                            }
                        },
                        new Purchase
                        {
                            OrderNumber = "DRD12345",
                            Date = DateTime.UtcNow.AddDays(-7),
                            PurchaseItems = new List<PurchaseItem>
                            {
                                new PurchaseItem { Product = ProductSeeder.SeedProduct[0], Quantity = 1 },
                                new PurchaseItem { Product = ProductSeeder.SeedProduct[2], Quantity = 2 } 
                            }
                        }
                    }
                }
            }; 
    }
}
