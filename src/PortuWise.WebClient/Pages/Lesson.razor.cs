using Microsoft.AspNetCore.Components;
using PortuWise.WebClient.ApiServices;
using PortuWise.WebClient.Domain.Responses;

namespace PortuWise.WebClient.Pages
{
    public partial class Lesson
    {
        [Parameter]
        public Guid CategoryId { get; set; }

        [Parameter]
        public Guid SubcategoryId { get; set; }

        [Inject]
        private ILessonApiService _lessonApiService { get; set; } = null!;

        [Inject]
        private IWordsApiService _wordsApiService { get; set; } = null!;

        private GetLessonResponse? _lessonResponse = null;
        private GetWordsResponse? _wordsResponse = null;

        private RenderFragment _htmlContent => builder =>
        {
            builder.AddMarkupContent(0, _lessonResponse.LessonHtml ?? "");
        };

        protected override async Task OnInitializedAsync()
        {
            _lessonResponse = await _lessonApiService.GetLessonAsync(SubcategoryId);
            StateHasChanged();

            _wordsResponse = await _wordsApiService.GetWordsAsync(SubcategoryId);
        }
    }
}
