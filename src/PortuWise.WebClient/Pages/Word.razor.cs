using Microsoft.AspNetCore.Components;
using PortuWise.WebClient.ApiServices;
using PortuWise.WebClient.Domain.Responses;

namespace PortuWise.WebClient.Pages
{
    public partial class Word
    {
        [Parameter]
        public Guid CategoryId { get; set; }

        [Parameter]
        public Guid SubcategoryId { get; set; }

        [Parameter]
        public Guid WordId { get; set; }

        private GetWordResponse? _wordResponse = null;

        [Inject]
        private IWordsApiService _wordsApiService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            _wordResponse = await _wordsApiService.GetWordAsync(WordId);
            StateHasChanged();
        }
    }
}
