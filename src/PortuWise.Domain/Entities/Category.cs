using PortuWise.Domain.Entities;

namespace PortuWise.WebApi.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
