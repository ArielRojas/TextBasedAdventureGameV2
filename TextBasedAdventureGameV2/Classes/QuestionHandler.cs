namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using TextBasedAdventureGameV2.Enums;

internal static class QuestionHandler
{
    private static bool _isAnswerCorrect = false;

    public static void SelectQuestionType(Question question, string[] options)
    {
        var actions = new Dictionary<QuestionType, Action>
            {
                { QuestionType.NO_CONFIRMATION, () => AskQuestionWithNoConfirmation(question) },
                { QuestionType.YES_CONFIRMATION, () => AskQuestionWithYesConfirmation(question) },
                { QuestionType.SIMPLE_SELECT, () =>  PromptQuestionWithSimpleSelect(question, options) }
            };

        actions[question.QuestionType]();
    }

    public static void AskQuestionWithNoConfirmation(Question question)
    {
        if (!AnsiConsole.Confirm($"[green]{question.QuestionDetail}[/]"))
        {
            AnsiConsole.MarkupLine("Muy bien, la respuesta es correcta.");
            _isAnswerCorrect = true;
        }
        else
        {
            AnsiConsole.MarkupLine($"Incorrecto, {question.Answer}");
            _isAnswerCorrect = false;
        }
    }

    public static void AskQuestionWithYesConfirmation(Question question)
    {
        if (AnsiConsole.Confirm($"[green]{question.QuestionDetail}[/]"))
        {
            AnsiConsole.MarkupLine("Muy bien, la respuesta es correcta.");
            _isAnswerCorrect = true;
        }
        else
        {
            AnsiConsole.MarkupLine($"Incorrecto, {question.Answer}");
            _isAnswerCorrect = false;
        }
    }

    public static void PromptQuestionWithSimpleSelect(Question question, string[] options)
    {
        var answer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[green]{question.QuestionDetail}[/]")
                .AddChoices(options));

        if (answer.Equals(question.Answer))
        {
            AnsiConsole.MarkupLine("Muy bien, la respuesta es correcta.");
            _isAnswerCorrect = true;
        }
        else
        {
            AnsiConsole.MarkupLine($"Incorrecto, la respuesta es {question.Answer}");
            _isAnswerCorrect = false;
        }
    }

    public static bool GetAnswerStatus()
    {
        return _isAnswerCorrect;
    }
}
