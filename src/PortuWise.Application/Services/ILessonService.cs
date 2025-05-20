using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface ILessonService
    {
        Task<Lesson?> GetLesson(Guid categoryId);
    }
}
