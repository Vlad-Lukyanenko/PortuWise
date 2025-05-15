using PortuWise.Domain.Entities;

namespace PortuWise.WebApi.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string LessonHtml { get; set; } = string.Empty;
    }
}
