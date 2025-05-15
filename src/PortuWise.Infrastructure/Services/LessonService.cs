using PortuWise.Application.Services;
using PortuWise.WebApi.Domain.Entities;

namespace PortuWise.WebApi.Services
{
    public class LessonService : ILessonService
    {
        private List<Lesson> _lessons;

        public LessonService()
        {
            _lessons = new List<Lesson>()
            {
                new Lesson()
                {
                    Id = Guid.Parse("ff1f0675-220c-4161-b617-9caedd2dcc86"),
                    CategoryId = Guid.Parse("c6c98a0c-be81-418a-8c94-7652fe935ede"),
                    LessonHtml =
                    """
                        <div class="container my-5">
                          <h2>💡Lesson: Greetings in European Portuguese</h2>
                          <h4>🇵🇹 Приветствия на португальском языке</h4>

                          <hr>

                          <h5>🧠 Цель урока:</h5>
                          <ul>
                            <li>Познакомиться с базовыми приветствиями и прощаниями</li>
                            <li>Понять, в каком контексте что использовать</li>
                            <li>Научиться здороваться формально и неформально</li>
                            <li>Начать маленький диалог</li>
                          </ul>

                          <hr>

                          <h5>💬 Нюансы и комментарии:</h5>
                          <ul>
                            <li><strong>Olá</strong> — нейтральное приветствие, подойдёт в любой ситуации</li>
                            <li><strong>Bom dia / Boa tarde / Boa noite</strong> — обязательно учитывай время суток (до 12:00 — <em>bom dia</em>, после — <em>boa tarde</em>, вечером/перед сном — <em>boa noite</em>)</li>
                            <li><strong>Tudo bem?</strong> — это не совсем вопрос “как ты?”, а скорее “всё норм?”. Даже говорят в ответ тоже “Tudo bem!”</li>
                            <li><strong>Tchau</strong> — звучит как итальянское “чао”, но это нормально, португальцы так и говорят</li>
                            <li><strong>Até logo</strong> — чаще используется, чем “tchau” в деловом или нейтральном контексте</li>
                          </ul>
                        </div>
                    """
                }
            };
        }

        public Lesson GetLesson(Guid categoryId)
        {
            var lesson = _lessons.SingleOrDefault(c => c.CategoryId == categoryId);

            if(lesson is null)
            {
                return new Lesson();
            }

            return lesson;
        }
    }
}
