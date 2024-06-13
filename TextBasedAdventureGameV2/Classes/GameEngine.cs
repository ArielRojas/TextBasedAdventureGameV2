namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using System.Threading;
using TextBasedAdventureGameV2.Builders;
using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Enums;

internal class GameEngine
{
    private Dictionary<int, Location> _freezerSagaLevels;
    private Dictionary<int, Location> _cellSagaLevels;
    private Player _player;

    public GameEngine()
    {
        _player = new Player("Default", 700, 200);
        _freezerSagaLevels = [];
        _cellSagaLevels = [];
    }

    public void ShowGameName()
    {
        AnsiConsole.MarkupInterpolated($"[bold darkgreen]{AnimationStrings.gameName}[/]");
    }

    public string GetPlayerName()
    {
        var name = AnsiConsole.Ask<string>("Cual es tu [bold orange1]nombre[/]?");
        var initialItem = new Item("Baculo Sagrado", ItemType.VELOCITY, "El báculo sagrado era de color rojo y fue un obsequio del abuelo Gohan para que el pequeño Son Gokú ingresara a la Torre del Maestro Karim, pues este objeto místico tenía la habilidad de incrementar de tamaño, pero su función principal era la de conectar esta localización con el Palacio del Dios de la Tierra, Kami- Sama.");
        _player.Name = name;
        _player.AddItem(initialItem);
        var welcome = $"\nBienvenido {name}!!!\n";
        AnsiConsole.MarkupInterpolated($"[bold orange1]{welcome}[/]");
        CommonActions.StartWithTheGame();

        return name;
    }

    public void ShowIntroduction()
    {
        Console.Clear();
        var panel = new Panel($"[orange1]{GameConstants.Introduction}[/]");
        panel.Header = new PanelHeader($"[bold]Dragon Ball Game[/]");
        panel.Expand = true;
        AnsiConsole.Write(panel);
        CommonActions.ContinueWithGame();
    }

    public void ShowInformationForPlayer()
    {
        AnsiConsole.MarkupLine($"[bold]{GameConstants.InformationForPlayer}\n[/]");
        AnsiConsole.MarkupInterpolated($"[orange1]{_player.Name} {GameConstants.InformationFirstSentence}\n[/]");
        AnsiConsole.MarkupLine($"[orange1]{GameConstants.InformationSecondSentence}[/]");
        AnsiConsole.MarkupLine($"[orange1]{GameConstants.InformationThirdSentence}[/]");
        AnsiConsole.MarkupLine($"[orange1]{GameConstants.InformationFourthSentence}[/]");
        AnsiConsole.MarkupLine($"[orange1]{GameConstants.InformationFifthSentence}[/]");
        CommonActions.ContinueWithGame();
    }

    public void InitializeObjectForFreezerSaga()
    {
        var location1 = LocationBuilder.BuildLocation(CommonConstants.ONE);
        location1.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.ONE));
        location1.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.TWO));
        var location2 = LocationBuilder.BuildLocation(CommonConstants.TWO);
        location2.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.THREE));
        location2.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.FOUR));
        var location3 = LocationBuilder.BuildLocation(CommonConstants.THREE);
        location3.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.FIVE));
        location3.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.SIX));
        var location4 = LocationBuilder.BuildLocation(CommonConstants.FOUR);
        location4.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.SEVEN));
        location4.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.EIGHT));
        var location5 = LocationBuilder.BuildLocation(CommonConstants.FIVE);
        location5.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.NINE));
        location5.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.TEN));

        _freezerSagaLevels[CommonConstants.ONE] = location1;
        _freezerSagaLevels[CommonConstants.TWO] = location2;
        _freezerSagaLevels[CommonConstants.THREE] = location3;
        _freezerSagaLevels[CommonConstants.FOUR] = location4;
        _freezerSagaLevels[CommonConstants.FIVE] = location5;
    }

    public void InitializeObjectsForCellSaga()
    {
        var location1 = LocationBuilder.BuildLocation(CommonConstants.SIX);
        location1.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.ONE));
        location1.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.TWO));
        var location2 = LocationBuilder.BuildLocation(CommonConstants.SEVEN);
        location2.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.THREE));
        location2.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.FOUR));
        var location3 = LocationBuilder.BuildLocation(CommonConstants.EIGHT);
        location3.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.FIVE));
        location3.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.SIX));
        var location4 = LocationBuilder.BuildLocation(CommonConstants.NINE);
        location4.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.SEVEN));
        location4.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.EIGHT));
        var location5 = LocationBuilder.BuildLocation(CommonConstants.TEN);
        location5.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.NINE));
        location5.Boss.AddQuestion(QuestionBuilder.BuildQuestion(CommonConstants.TEN));

        _cellSagaLevels[CommonConstants.ONE] = location1;
        _cellSagaLevels[CommonConstants.TWO] = location2;
        _cellSagaLevels[CommonConstants.THREE] = location3;
        _cellSagaLevels[CommonConstants.FOUR] = location4;
        _cellSagaLevels[CommonConstants.FIVE] = location5;
    }

    public void PlayGame()
    {
        ShowGameName();
        GetPlayerName();
        ShowIntroduction();
        ShowInformationForPlayer();
        ShowOptions(GameConstants.FreezerSaga, GameConstants.CellSaga);
    }

    public void PlayFreezerSaga()
    {
        InitializeObjectForFreezerSaga();
        PlaySaga(_freezerSagaLevels);
    }

    public void PlayCellSaga()
    {
        InitializeObjectsForCellSaga();
        PlaySaga(_cellSagaLevels);
    }

    private void ShowOptions(params string[] options)
    {
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title($"[green]{GameConstants.ChooseSaga}[/]")
            .AddChoices(options));

        var optionsToChoose = new Dictionary<string, Action>
            {
                {GameConstants.FreezerSaga, PlayFreezerSaga},
                {GameConstants.CellSaga, PlayCellSaga}
            };

        optionsToChoose[option]();
    }

    private void PrintDragon()
    {
        AnsiConsole.MarkupInterpolated($"[bold darkgreen]{AnimationStrings.dragon}[/]");
    }

    private void PlaySaga(Dictionary<int, Location> saga)
    {
        var finishFlag = false;
        var level = 1;

        while (_player.LifePoints > 0 && !finishFlag)
        {
            var list = saga[level].InteractInGame(_player, level);
            level = (int)list[CommonConstants.ZERO];
            var doesPlayerWin = (bool)list[CommonConstants.ONE];

            if (level > CommonConstants.FIVE || saga[level].Boss.Equals(BossConstants.BossName5) || saga[level].Boss.Equals(BossConstants.BossName10))
            {
                if (doesPlayerWin)
                {
                    ShowEndGameCredits();
                    finishFlag = true;
                }
            }
        }
    }

    private void ShowEndGameCredits()
    {
        Console.WriteLine($"{GameConstants.FinalPartFourthSentence}");
        Thread.Sleep(AnimationStrings.sleep);
        Console.Clear();
        PrintDragon();
        Console.WriteLine($"\n{_player.Name} {GameConstants.FinalPartFifthSentence}");
        Thread.Sleep(AnimationStrings.sleep);
        Console.WriteLine($"{GameConstants.FinalPartSixthSentence}");
        Thread.Sleep(AnimationStrings.sleep);
        Console.WriteLine($"{GameConstants.FinalPartSevenSentence}");
        Thread.Sleep(AnimationStrings.sleep);
    }
}