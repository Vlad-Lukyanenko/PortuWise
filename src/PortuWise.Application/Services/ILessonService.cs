using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.Application.Services
{
    public interface ILessonService
    {
        Lesson GetLesson(Guid categoryId);
    }
}
