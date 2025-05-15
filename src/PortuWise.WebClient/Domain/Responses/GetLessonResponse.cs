namespace PortuWise.WebClient.Domain.Responses
{
    public class GetLessonResponse
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ParentCategoryId { get; set; }
        public string LessonHtml { get; set; } = string.Empty;
    }
}
