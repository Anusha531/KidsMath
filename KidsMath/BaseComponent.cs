using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace KidsMath
{
    public abstract class BaseComponent<TProblem> : ComponentBase
    {
       

        [Inject]
        public NavigationManager NavigationManager { get; set; }

       

        protected List<TProblem> Problems { get; set; } = new List<TProblem>();
        protected bool ShowCongrats { get; set; } = false;

        [Parameter]
        public virtual int QuestionCount { get; set; } = 3;

        [Parameter]
        public EventCallback<int> OnQuestionCountChange { get; set; }

        [Parameter]
        public EventCallback OnNextActionClicked { get; set; }

        [Parameter]
        public int GradeCourseId { get; set; }

        protected double CompletionPercentage { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            await InitializeGame();
        }

        private async Task InitializeGame()
        {
            ShowCongrats = false;
            Problems = GenerateQuestions(QuestionCount);           
        }       

        protected abstract List<TProblem> GenerateQuestions(int questionCount);

        protected async Task SubmitAnswers()
        {
            ShowCongrats = AllAnswersCorrect(Problems);
            if (ShowCongrats)
            {
               
                await RefreshProblems();
            }
        }

       

        private async Task RefreshProblems()
        {
            Problems = GenerateQuestions(QuestionCount);
            await Task.Delay(1000); // Simulate a delay for UI update
            ShowCongrats = false;
            StateHasChanged();
        }

        protected abstract bool AllAnswersCorrect(List<TProblem> problems);

        protected async Task OnQuestionCountChanged(int count)
        {
            QuestionCount = count;
            await InitializeGame();
        }
    }
}
