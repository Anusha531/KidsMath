using static KidsMath.Components.Pages.Grade5.Measurement;

namespace KidsMath.Service
{
    public class MeasurementService : IMeasurementService
    {
        private const string inches = "Inches";
        private const string feet = "Feet";

        private static readonly List<string> standardOptions = [inches, feet];

        private readonly List<OptionsModel> emojiQuestions =
        [
            new OptionsModel
            {
                Question = "🖍️ (Crayon) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🛏️ (Bed) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🚪 (Door) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🍎 (Apple) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🖥️ (Computer monitor) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🚗 (Car) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "📏 (Ruler) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🌳 (Tree) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "📱 (Phone) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "📚 (Book) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🚴‍♀️ (Bicycle) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🏠 (House) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "✏️ (Pencil) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "💻 (Laptop) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🏀 (Basketball) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "⏰ (Clock) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🚒 (Fire Truck) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🎒 (Backpack) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🚙 (SUV) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🖼️ (Picture frame) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = inches
            },
            new OptionsModel
            {
                Question = "🛹 (Skateboard) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🚂 (Train) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🏡 (Garden) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            },
            new OptionsModel
            {
                Question = "🐕 (Dog) Should this be measured in:",
                Options = standardOptions,
                CorrectAnswer = feet
            }
        ];

        public List<OptionsModel> GetEmojiQuestions(int questionCount)
        {
            var random = new Random();
            return emojiQuestions.OrderBy(_ => random.Next()).Take(questionCount).Select(q => { q.IsAnswered = false; q.IsCorrect = false; return q; }).ToList();
        }
    }

    public class OptionsModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<string> Options { get; set; } = [];
        public string CorrectAnswer { get; set; } = string.Empty;
        public string UserAnswer { get; set; } = string.Empty;
        public bool IsAnswered { get; set; } = false;
        public bool IsCorrect { get; set; } = false;
        public string Question { get; set; } = string.Empty;
    }
}
