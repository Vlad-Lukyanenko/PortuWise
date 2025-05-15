using Microsoft.AspNetCore.Components;
using PortuWise.WebClient.ApiServices;

namespace PortuWise.WebClient.Pages
{
    public partial class Category
    {
        [Parameter]
        public Guid CategoryId { get; set; }

        [Inject]
        private ICategoryApiService CategoryApiService { get; set; } = null!;

        private List<Domain.Category> _subCategories;

        public Category()
        {
            _subCategories = new List<Domain.Category>();
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _subCategories = (await CategoryApiService.GetSubcategoriesAsync(CategoryId)).ToList();
            }
            catch (Exception ex)
            {
                // Handle any errors - you might want to log or display error messages
                Console.WriteLine($"Error loading categories: {ex.Message}");
                // Optionally set up error state for UI
            }
        }
    }
}
