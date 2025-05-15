namespace PortuWise.WebClient.Domain
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string LessonHtml { get; set; } = string.Empty;
    }
}
