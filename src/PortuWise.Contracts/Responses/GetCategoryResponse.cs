namespace PortuWise.Contracts.Responses
{
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
