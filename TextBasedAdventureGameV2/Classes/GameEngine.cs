namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using System.Threading;
using TextBasedAdventureGameV2.Builders;
using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Enums;

internal class GameEngine
{
    private readonly Stack<Location> _stackFirstOption;
    private readonly Stack<Location> _stackSecondOption;
    private Player _player;
    private int _level;

    public GameEngine()
    {
        _player = new Player("Default", 700, 200);
        _level = 1;
        _stackFirstOption = [];
        _stackSecondOption = [];
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
        Thread.Sleep(AnimationStrings.sleep);

        return name;
    }

    public void ShowIntroduction()
    {
        Console.Clear();
        var panel = new Panel($"[orange1]{GameConstants.Introduction}[/]");
        panel.Header = new PanelHeader($"[bold]Dragon Ball Game[/]");
        panel.Expand = true;
        AnsiConsole.Write(panel);
        Console.WriteLine(GameConstants.PressKeyToStartGame);
        Console.ReadKey();
        Console.Clear();
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
        Console.Clear();
    }

    public void InitializeFirstStack()
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

        _stackFirstOption.Push(location5);
        _stackFirstOption.Push(location4);
        _stackFirstOption.Push(location3);
        _stackFirstOption.Push(location2);
        _stackFirstOption.Push(location1);
    }

    public void InitializeSecondStack()
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

        _stackSecondOption.Push(location5);
        _stackSecondOption.Push(location4);
        _stackSecondOption.Push(location3);
        _stackSecondOption.Push(location2);
        _stackSecondOption.Push(location1);
    }

    public void PlayGame()
    {
        ShowGameName();
        GetPlayerName();
        ShowIntroduction();
        ShowInformationForPlayer();
        ShowOptions(GameConstants.FreezerSaga, GameConstants.CellSaga);
    }

    public Stack<Location> GetStackBySaga(string saga)
    {
        if (saga.Equals(GameConstants.FreezerSaga))
        {
            return _stackFirstOption;
        }
        else
        {
            return _stackSecondOption;
        }
    }

    public void PlayFreezerSaga()
    {
        InitializeFirstStack();
        PlaySaga(_stackFirstOption);
    }

    public void PlayCellSaga()
    {
        InitializeSecondStack();
        PlaySaga(_stackSecondOption);
    }

    private void PlaySaga(Stack<Location> stack)
    {
        var finishFlag = false;

        while (_player.LifePoints > 0 && !finishFlag)
        {
            var recoverLifePoints = 0;

            switch (_level)
            {
                case 1:
                    _player.AnsweredQuestionsNumber = 0;
                    var location = stack.Peek();
                    var boss = location.Boss;
                    var item = boss.Item;
                    location.ShowLocationInformation();
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(0)));
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(1)));
                    boss.ShowPoints();
                    _player.ShowPoints();
                    _player.ShowInformation(PlayerConstants.DisplayItems, PlayerConstants.DisplayLifeAndAttackPoints, PlayerConstants.ContinueWithGame);
                    _player.IncreasePower(_player.SelectItemToFight());
                    _player.ShowPoints();
                    while (boss.LifePoints > 0 && _player.LifePoints > 0)
                    {
                        _player.InteractInGame(boss);
                        if (boss.LifePoints <= 0)
                        {
                            break;
                        }
                        boss.InteractInGame(_player);
                        recoverLifePoints += boss.AttackPoints;
                    }

                    if (_player.LifePoints > 0)
                    {
                        Console.WriteLine($"Felicidades!!!, lograste vencer a {boss.Name}.");
                        Console.WriteLine($"Ganaste el item: {item.Name}");
                        _player.AddItem(item);
                        _player.LifePoints += recoverLifePoints;
                        CommonActions.ContinueWithGame();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Perdiste, la siguiente vez lo haras mejor.");
                    }

                    stack.Pop();

                    _level = WinWilcard(_player, boss, _level, stack);
                    break;

                case 2:
                    _player.AnsweredQuestionsNumber = 0;
                    location = stack.Peek();
                    boss = location.Boss;
                    item = boss.Item;
                    location.ShowLocationInformation();
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(0)));
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(1)));
                    boss.ShowPoints();
                    _player.ShowPoints();
                    _player.ShowInformation(PlayerConstants.DisplayItems, PlayerConstants.DisplayLifeAndAttackPoints, PlayerConstants.ContinueWithGame);
                    _player.IncreasePower(_player.SelectItemToFight());
                    _player.ShowPoints();
                    while (boss.LifePoints > 0 && _player.LifePoints > 0)
                    {
                        _player.InteractInGame(boss);
                        if (boss.LifePoints <= 0)
                        {
                            break;
                        }
                        boss.InteractInGame(_player);
                        recoverLifePoints += boss.AttackPoints;
                    }

                    if (_player.LifePoints > 0)
                    {
                        Console.WriteLine($"Felicidades!!!, lograste vencer a {boss.Name}.");
                        Console.WriteLine($"Ganaste el item: {item.Name}");
                        _player.AddItem(item);
                        _player.LifePoints += recoverLifePoints;
                        CommonActions.ContinueWithGame();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Perdiste, la siguiente vez lo haras mejor.");
                    }

                    stack.Pop();
                    _level = WinWilcard(_player, boss, _level, stack);
                    break;

                case 3:
                    _player.AnsweredQuestionsNumber = 0;
                    location = stack.Peek();
                    boss = location.Boss;
                    item = boss.Item;
                    location.ShowLocationInformation();
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(0)));
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(1)));
                    boss.ShowPoints();
                    _player.ShowPoints();
                    _player.ShowInformation(PlayerConstants.DisplayItems, PlayerConstants.DisplayLifeAndAttackPoints, PlayerConstants.ContinueWithGame);
                    _player.IncreasePower(_player.SelectItemToFight());
                    _player.ShowPoints();
                    while (boss.LifePoints > 0 && _player.LifePoints > 0)
                    {
                        _player.InteractInGame(boss);
                        if (boss.LifePoints <= 0)
                        {
                            break;
                        }
                        boss.InteractInGame(_player);
                        recoverLifePoints += boss.AttackPoints;
                    }

                    if (_player.LifePoints > 0)
                    {
                        Console.WriteLine($"Felicidades!!!, lograste vencer a {boss.Name}.");
                        Console.WriteLine($"Ganaste el item: {item.Name}");
                        _player.AddItem(item);
                        _player.LifePoints += recoverLifePoints;
                        CommonActions.ContinueWithGame();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Perdiste, la siguiente vez lo haras mejor.");
                    }

                    stack.Pop();
                    _level = WinWilcard(_player, boss, _level, stack);
                    break;

                case 4:
                    _player.AnsweredQuestionsNumber = 0;
                    location = stack.Peek();
                    boss = location.Boss;
                    item = boss.Item;
                    location.ShowLocationInformation();
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(0)));
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(1)));
                    boss.ShowPoints();
                    _player.ShowPoints();
                    _player.ShowInformation(PlayerConstants.DisplayItems, PlayerConstants.DisplayLifeAndAttackPoints, PlayerConstants.ContinueWithGame);
                    _player.IncreasePower(_player.SelectItemToFight());
                    _player.ShowPoints();
                    while (boss.LifePoints > 0 && _player.LifePoints > 0)
                    {
                        _player.InteractInGame(boss);
                        if (boss.LifePoints <= 0)
                        {
                            break;
                        }
                        boss.InteractInGame(_player);
                        recoverLifePoints += boss.AttackPoints;
                    }

                    if (_player.LifePoints > 0)
                    {
                        Console.WriteLine($"Felicidades!!!, lograste vencer a {boss.Name}.");
                        Console.WriteLine($"Ganaste el item: {item.Name}");
                        _player.AddItem(item);
                        _player.LifePoints += recoverLifePoints;
                        CommonActions.ContinueWithGame();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Perdiste, la siguiente vez lo haras mejor.");
                    }

                    stack.Pop();
                    _level = WinWilcard(_player, boss, _level, stack);
                    break;

                case 5:
                    _player.AnsweredQuestionsNumber = 0;
                    location = stack.Peek();
                    boss = location.Boss;
                    item = boss.Item;
                    location.ShowLocationInformation();
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(0)));
                    boss.VerifyAnswerIsCorrect(_player, boss.AskQuestion(location.Boss.getQuestion(1)));
                    boss.ShowPoints();
                    _player.ShowPoints();
                    _player.ShowInformation(PlayerConstants.DisplayItems, PlayerConstants.DisplayLifeAndAttackPoints, PlayerConstants.ContinueWithGame);
                    _player.IncreasePower(_player.SelectItemToFight());
                    _player.ShowPoints();
                    while (boss.LifePoints > 0 && _player.LifePoints > 0)
                    {
                        _player.InteractInGame(boss);
                        if (boss.LifePoints <= 0)
                        {
                            break;
                        }
                        boss.InteractInGame(_player);
                    }

                    if (_player.LifePoints > 0)
                    {
                        _player.AddItem(item);
                        _player.LifePoints += recoverLifePoints;
                        Console.WriteLine($"{GameConstants.FinalPartFirstSentence} {boss.Name}.");
                        Thread.Sleep(AnimationStrings.sleep);
                        Console.WriteLine($"{GameConstants.FinalPartSecondSentence} {item.Name}, {GameConstants.FinalPartThirdSentence}");
                        Thread.Sleep(AnimationStrings.sleep);
                        Console.WriteLine($"{GameConstants.FinalPartFourthSentence}");
                        Thread.Sleep(AnimationStrings.sleep);
                        Console.Clear();
                        PrintDragon();
                        Console.WriteLine($"\n{_player.Name} {GameConstants.FinalPartFifthSentence}");
                        Thread.Sleep(AnimationStrings.sleep);
                        Console.WriteLine($"{GameConstants.FinalPartSixthSentence}");
                        Console.WriteLine($"{GameConstants.FinalPartSevenSentence}");
                    }
                    else
                    {
                        Console.WriteLine($"{GameConstants.FinalPartLoseSentence}");
                    }

                    stack.Pop();
                    _level = WinWilcard(_player, boss, _level, stack);

                    break;
                default:
                    finishFlag = true;
                    break;
            }
        }
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

    private int WinWilcard(Player player, Boss boss, int level, Stack<Location> stack)
    {
        int result;

        if (player.AnsweredQuestionsNumber == 2 && boss.WildcardOption == WildcardOption.YES)
        {
            stack.Pop();
            result = level + 2;
        }
        else
        {
            result = level + 1;
        }

        return result;
    }
}
