using Microsoft.EntityFrameworkCore;
using PortuWise.DataAccess;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Infrastructure.DbSeeder
{
    internal class SeedCategories
    {
        private PortuWiseDbContext _dbContext;

        private List<Category> _categories;

        public SeedCategories(PortuWiseDbContext dbContext)
        {
            _dbContext = dbContext;

            _categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.Parse("0c7c367c-0d51-4013-b48c-e67024bb67cf"),
                    ParentId = null,
                    ImagePath = "./images/default.jpg",
                    Title = "Greetings & Basics",
                    Description = "Start your Portuguese journey with essential greetings, polite expressions, and simple phrases for everyday conversations.",
                    CreatedAt = DateTime.UtcNow
                },
                new Category()
                {
                    Id = Guid.Parse("2f3d8a0e-5ce3-485d-9ede-02ef1a468f01"),
                    ParentId = null,
                    ImagePath = "./images/default.jpg",
                    Title = "Home & Daily Life",
                    Description = "Learn words and expressions related to home, furniture, chores, and everything you use in your daily routine.",
                    CreatedAt = DateTime.UtcNow
                },
                new Category()
                {
                    Id = Guid.Parse("a14b9006-daec-41a3-8b90-b09cc343204b"),
                    ParentId = null,
                    ImagePath = "./images/default.jpg",
                    Title = "Family & Relationships",
                    Description = "Explore vocabulary for family members, personal relationships, and emotional expressions to connect on a deeper level.",
                    CreatedAt = DateTime.UtcNow
                },
                new Category()
                {
                    Id = Guid.Parse("0ea75a84-cc46-4838-b26f-797f2892dd58"),
                    ParentId = null,
                    ImagePath = "./images/default.jpg",
                    Title = "Shopping & Food",
                    Description = "Discover how to talk about groceries, meals, prices, and shopping essentials — from markets to restaurants.",
                    CreatedAt = DateTime.UtcNow
                },

                //Sub categories
                new Category()
                {
                    Id = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
                    ParentId = Guid.Parse("0c7c367c-0d51-4013-b48c-e67024bb67cf"),
                    ImagePath = "./images/sub_default.png",
                    Title = "Приветствия / Greetings",
                    Description = "(Olá, Bom dia, Tudo bem)",
                    CreatedAt = DateTime.UtcNow
                },
                new Category()
                {
                    Id = Guid.Parse("e91bbe15-18a8-4c4b-aaa9-f4fd8ff14acc"),
                    ParentId = Guid.Parse("0c7c367c-0d51-4013-b48c-e67024bb67cf"),
                    ImagePath = "./images/sub_default.png",
                    Title = "Прощания / Goodbyes",
                    Description = "(Tchau, Até logo)",
                    CreatedAt = DateTime.UtcNow
                },
                new Category()
                {
                    Id = Guid.Parse("685363ef-1dd8-4057-9eed-24b4c2db9c1f"),
                    ParentId = Guid.Parse("0c7c367c-0d51-4013-b48c-e67024bb67cf"),
                    ImagePath = "./images/sub_default.png",
                    Title = "Вежливость / Politeness",
                    Description = "(Por favor, Obrigado, Com licença)",
                    CreatedAt = DateTime.UtcNow
                },
                new Category()
                {
                    Id = Guid.Parse("e487265d-f2b5-436b-a4be-a8b40e34d47d"),
                    ParentId = Guid.Parse("0c7c367c-0d51-4013-b48c-e67024bb67cf"),
                    ImagePath = "./images/sub_default.png",
                    Title = "Представления / Introducing Yourself",
                    Description = "(Como te chamas?, Eu sou o João)",
                    CreatedAt = DateTime.UtcNow
                }
            };
        }

        public async Task Seed()
        {
            foreach (var category in _categories)
            {
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

                if (existingCategory is null)
                {
                    _dbContext.Categories.Add(category);
                }
                else
                { 
                    existingCategory.Title = category.Title;
                    existingCategory.ParentId = category.ParentId;
                    existingCategory.ImagePath = category.ImagePath;
                    existingCategory.Description = category.Description;
                    existingCategory.UpdatedAt = DateTime.UtcNow;
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
