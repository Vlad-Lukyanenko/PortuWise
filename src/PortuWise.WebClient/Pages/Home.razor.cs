using Microsoft.AspNetCore.Components;
using PortuWise.WebClient.ApiServices;

namespace PortuWise.WebClient.Pages
{
    public partial class Home
    {
        private List<Domain.Category> _categories;

        [Inject]
        private ICategoryApiService CategoryApiService { get; set; }

        public Home()
        {
            _categories = new List<Domain.Category>();
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _categories = (await CategoryApiService.GetRootCategoriesAsync()).ToList();
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
