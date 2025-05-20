using Microsoft.AspNetCore.Components;
using PortuWise.WebClient.Domain;
using PortuWise.WebClient.Domain.Enums;

namespace PortuWise.WebClient.MyComponents
{
    public partial class FlashCard
    {
        [Parameter]
        public List<Word> Words { get; set; } = null!;

        private readonly Random _random = new();
        private List<Word> _playedWords { get; set; } = null!;

        //private List<Phrase> _phrases;
        public int NumberOfQuestion { get; set; }
        public FlashCardType GameType { get; set; }
        public Word CurrentWord { get; set; } = null!;
        public Phrase CurrentPhrase { get; set; } = null!;
        public Guid? SelectedWordOptionId { get; set; } = null!;
        public Guid? SelectedPhraseOptionId { get; set; } = null!;
        public bool IsCorrectWord { get; set; } = false;
        public bool IsCorrectPhrase { get; set; } = false;
        public bool IsAnswered { get; set; } = false;

        public List<Word> Options { get; set; } = null!;
        public int NumberOfMistakes { get; set; } = 0;

        public bool IsStarted { get; set; } = false;
        public bool IsFinished { get; set; } = false;
        public int NumberOfWords { get { return Words.Count; } }

        public void StartNew(FlashCardType type)
        {
            NumberOfQuestion = 1;
            GameType = type;
            IsAnswered = false;
            NumberOfMistakes = 0;
            SelectedWordOptionId = null;
            IsStarted = true;
            IsFinished = false;
            _playedWords = new List<Word>();
            CurrentWord = GetRandomWord()!;
            CurrentPhrase = GetRandomPhrase(CurrentWord);
            Options = GetRandomDistractors(CurrentWord.Id);
            RundomisePhrases();
        }

        public void GoBack()
        {
            IsStarted = false;
            IsFinished = false;
        }

        public void FinishFlashCards()
        {
            IsStarted = false;
        }

        public void CheckWordOption(Guid id)
        {
            if (!IsAnswered)
            {
                SelectedWordOptionId = id;
                IsCorrectWord = CurrentWord.Id == id;

                if (!IsCorrectWord)
                {
                    NumberOfMistakes++;
                }
            }

            IsAnswered = true;
        }

        public void CheckPhraseOption(Guid phraseId)
        {
            if (!IsAnswered)
            {
                SelectedPhraseOptionId = phraseId;
                IsCorrectPhrase = CurrentPhrase.Id == phraseId;

                if (!IsCorrectPhrase)
                {
                    NumberOfMistakes++;
                }
            }

            IsAnswered = true;
        }

        public void NextWord()
        {
            if (IsAnswered)
            {
                NumberOfQuestion++;
                IsCorrectWord = false;
                SelectedWordOptionId = null;
                CurrentWord = GetRandomWord()!;

                if (CurrentWord is null)
                {
                    IsFinished = true;
                    return;
                }

                Options = GetRandomDistractors(CurrentWord.Id);
                
                CurrentPhrase = GetRandomPhrase(CurrentWord);
                RundomisePhrases();
                StateHasChanged();

                IsAnswered = false;
            }
        }

        public Word? GetRandomWord()
        {
            var filteredWords = Words
                .Where(option => !_playedWords.Any(b => b.Id == option.Id))
                .ToList();

            if (filteredWords.Count == 0)
            {
                IsFinished = true;

                return null;
            }

            var result = filteredWords[_random.Next(filteredWords.Count)];
            _playedWords.Add(result);

            return result;
        }

        public Phrase GetRandomPhrase(Word word)
        {
            var phrase = word.Phrases[_random.Next(word.Phrases.Count)];

            return phrase;
        }

        public void RundomisePhrases()
        {
            var random = new Random();
            CurrentWord.Phrases = CurrentWord.Phrases.OrderBy(x => random.Next()).ToList();
        }

        public List<Domain.Word> GetRandomDistractors(Guid extractWordId, int count = 3)
        {
            var randomWords = Words
                .Where(w => w.Id != extractWordId)
                .OrderBy(_ => _random.Next())
                .Take(count)
                .ToList();

            randomWords.Add(CurrentWord);

            return randomWords.OrderBy(_ => _random.Next()).ToList();
        }
    }
}
