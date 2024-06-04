namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;

internal class QuestionHandler
{
    public static bool AskQuestionWithNoConfirmation(Question question)
    {
        if (!AnsiConsole.Confirm($"[green]{question.QuestionDetail}[/]"))
        {
            AnsiConsole.MarkupLine("Muy bien, la respuesta es correcta.");

            return true;
        }

        return false;
    }

    public static bool AskQuestionWithYesConfirmation(Question question)
    {
        if (AnsiConsole.Confirm($"[green]{question.QuestionDetail}[/]"))
        {
            AnsiConsole.MarkupLine("Muy bien, la respuesta es correcta.");

            return false;
        }

        return true;
    }

    public static string PromptQuestionWithSimpleSelect(Question question, string[] options)
    {
        var answer = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[green]{question.QuestionDetail}[/]")
                .AddChoices(options));

        return answer;
    }
}
