namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Enums;

public class Location
{
    public string Detail { get; set; }
    public Boss Boss { get; set; }

    public Location(string detail, Boss boss)
    {
        Detail = detail;
        Boss = boss;
    }

    public void ShowLocationInformation()
    {
        Console.WriteLine("==============================================================================================\n");
        AnsiConsole.WriteLine($"Detalle de la localidad: {Detail} \nJefe: {Boss.Name} \nDetalles del Jefe: {Boss.Description}");
        Console.WriteLine("\n==============================================================================================\n");
    }

    public List<object> InteractInGame(Player player, int level)
    {
        List<object> results = new();
        var doesLevelWin = false;
        player.AnsweredQuestionsNumber = 0;
        var recoverLifePoints = 0;
        ShowLocationInformation();
        Boss.VerifyAnswerIsCorrect(player, Boss.AskQuestion(Boss.getQuestion(0)));
        Boss.VerifyAnswerIsCorrect(player, Boss.AskQuestion(Boss.getQuestion(CommonConstants.ONE)));
        Boss.ShowPoints();
        player.ShowPoints();
        player.ShowInformation(PlayerConstants.DisplayItems, PlayerConstants.DisplayLifeAndAttackPoints, PlayerConstants.ContinueWithGame);
        player.IncreasePower(player.SelectItemToFight());
        player.ShowPoints();
        while (Boss.LifePoints > 0 && player.LifePoints > 0)
        {
            player.InteractInGame(Boss);
            if (Boss.LifePoints <= 0)
            {
                break;
            }
            Boss.InteractInGame(player);
            recoverLifePoints += Boss.AttackPoints;
        }

        if (player.LifePoints > 0)
        {
            Console.WriteLine($"{GameConstants.FinalPartFirstSentence} {Boss.Name}.");
            Console.WriteLine($"Ganaste el item: {Boss.Item.Name}");
            player.AddItem(Boss.Item);
            player.LifePoints += recoverLifePoints;
            CommonActions.ContinueWithGame();
            doesLevelWin = true;
        }
        else
        {
            Console.WriteLine(GameConstants.FinalPartLoseSentence);
        }

        level = WinWilcard(player, level);
        results.Add(level);
        results.Add(doesLevelWin);

        return results;
    }

    private int WinWilcard(Player player, int level)
    {
        int result;

        if (level < CommonConstants.FIVE)
        {
            if (player.AnsweredQuestionsNumber == 2 && Boss.WildcardOption == WildcardOption.YES)
            {
                result = level + 2;
            }
            else
            {
                result = level + 1;
            }
        }
        else
        {
            result = level + 1;
        }

        return result;
    }
}
