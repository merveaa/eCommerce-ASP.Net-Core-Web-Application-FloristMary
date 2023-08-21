using FloristMary.Models;
using Microsoft.EntityFrameworkCore;

namespace FloristMary.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context) //We create initial data in here 
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Category houseplants = new Category { Name = "House Plants", Slug = "houseplants" };
                Category bouqets = new Category { Name = "Bouqets", Slug = "bouqets" };

                context.Products.AddRange(
                new Product
                {
                    Name = "CHARMING HEART",
                    Price = 89.99M,
                    Slug = "l9fıbvne",
                    Image = "p1.jpg",
                    Category = houseplants

                },
                        new Product
                        {
                            Name = "VALENTINE'S SPECIAL ROSES\r\n",
                            Slug = "l9fıbvne",
                            Price = 79.99M,
                            Image = "p2.jpg",
                            Category = houseplants

                        },
                        new Product
                        {
                            Name = "LOVE NEST",
                            Slug = "l9fıbvne",
                            Price = 69.99M,
                            Image = "p3.jpg",
                            Category = houseplants
                        },
                        new Product
                        {
                            Name = "CRINKLY CUT",
                            Slug = "l9fıbvne",
                            Price = 99.99M,
                            Image = "p4.jpg",
                            Category = houseplants
                        },
                        new Product
                        {
                            Name = "HEART GARDEN ROSES",
                            Slug = "l9fıbvne",
                            Price = 89.99M,
                            Image = "p9.jpg",
                            Category = bouqets
                        },
                        new Product
                        {
                            Name = "TULIP WHISPER",
                            Slug = "l9fıbvne",
                            Price = 79.99M,
                            Image = "p5.jpg",
                            Category = houseplants
                        },
                        new Product
                        {
                            Name = "DREAMY PINKS",
                            Slug = "l9fıbvne",
                            Price = 69.99M,
                            Image = "p6.jpg",
                            Category = houseplants
                        },
                        new Product
                        {
                            Name = "CYMBIDIUM DREAM",
                            Slug = "l9fıbvne",
                            Price = 75M,
                            Image = "p7.jpg",
                            Category = houseplants
                        },
                        new Product
                        {
                            Name = "LIVING CORAL",
                            Slug = "l9fıbvne",
                            Price = 89.99M,
                            Image = "p8.jpg",
                            Category = houseplants
                        }
                );
                context.SaveChanges();
            }
        }
    }
}