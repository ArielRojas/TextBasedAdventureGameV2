namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using System.Threading;
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

        var item1 = new Item("Semillas del hermitanio", ItemType.SANITY, "Recupera tus energias.");
        var question1 = new Question(QuestionConstants.Question1, QuestionConstants.Answer1, QuestionType.NO_CONFIRMATION);
        var question2 = new Question(QuestionConstants.Question2, QuestionConstants.Answer2, QuestionType.SIMPLE_SELECT);
        question2.AddOptions(["Oolong", "Puar", "Ten Ten"]);
        var boss1 = new Boss("Gurdo", "Tiene grandes poderes psíquicos", item1, 1000, 200, WildcardOption.YES);
        boss1.AddQuestion(question1);
        boss1.AddQuestion(question2);
        var location1 = new Location("Hay alguien que control el tiempo con poderes  psíquicos.", boss1);

        var item2 = new Item("KAME HAME HA", ItemType.POWER, "Gran cantidad de energía en las manos.");
        var question3 = new Question(QuestionConstants.Question3, QuestionConstants.Answer3, QuestionType.YES_CONFIRMATION);
        var question4 = new Question(QuestionConstants.Question4, QuestionConstants.Answer4, QuestionType.SIMPLE_SELECT);
        question4.AddOptions(["Mr. Satan", "Maestro Roshi", "Kamisama"]);
        var boss2 = new Boss("Rikum", "Es un villano con mucha fuerza.", item2, 1200, 300, WildcardOption.NO);
        boss2.AddQuestion(question3);
        boss2.AddQuestion(question4);
        var location2 = new Location("Una Fuerza sobrehumana esta frente a ti.", boss2);

        var item3 = new Item("Kaioken", ItemType.VELOCITY, "Es una técnica poderosa que permite a los guerreros aumentar su fuerza y velocidad temporalmente.");
        var question5 = new Question(QuestionConstants.Question5, QuestionConstants.Answer5, QuestionType.SIMPLE_SELECT);
        question5.AddOptions(["Resplandor Final", "Genki-dama", "Makankosappo"]);
        var question6 = new Question(QuestionConstants.Question6, QuestionConstants.Answer6, QuestionType.NO_CONFIRMATION);
        Boss boss3 = new Boss("Jheese", "Es un villano con gran velocidad.", item3, 1800, 400, WildcardOption.YES);
        boss3.AddQuestion(question5);
        boss3.AddQuestion(question6);
        var location3 = new Location("Aumenta tu velocidad.", boss3);

        var item4 = new Item("Genki-dama", ItemType.POWER, "Es una técnica de combate de naturaleza ofensiva que requiere una parte de la energía de todas las criaturas.");
        var question7 = new Question(QuestionConstants.Question7, QuestionConstants.Answer7, QuestionType.SIMPLE_SELECT);
        question7.AddOptions(["Mark", "Miguel", "Kenny"]);
        var question8 = new Question(QuestionConstants.Question8, QuestionConstants.Answer8, QuestionType.SIMPLE_SELECT);
        question8.AddOptions(["Gold Freezer", "Kid Buu", "Mr. Buu"]);
        var boss4 = new Boss("Capitán Ginyu", "Es el lider de las Fuerzas Especiales Ginyu.", item4, 2000, 500, WildcardOption.NO);
        boss4.AddQuestion(question7);
        boss4.AddQuestion(question8);
        var location4 = new Location("Cuidate de la tecnica especial del Capitan Ginyu", boss4);

        var item5 = new Item("Esferas del Dragon", ItemType.POWER, "Son 7 esferas que te ayudan a llamar a Shen Long para pedir un deseo.");
        var question9 = new Question(QuestionConstants.Question9, QuestionConstants.Answer9, QuestionType.SIMPLE_SELECT);
        question9.AddOptions([ "Gohan", "Vegeta", "Goku" ]);
        var question10 = new Question(QuestionConstants.Question10, QuestionConstants.Answer10, QuestionType.SIMPLE_SELECT);
        question10.AddOptions(["Mr. Satan", "Babidi", "Tao pai pai"]);
        var boss5 = new Boss("Freezer", "Es un tirano intergaláctico, es el lider final de esta saga.", item5, 2400, 600, WildcardOption.NO);
        boss5.AddQuestion(question9);
        boss5.AddQuestion(question10);
        var location5 = new Location("El mundo esta en peligro.", boss5);

        _stackFirstOption.Push(location5);
        _stackFirstOption.Push(location4);
        _stackFirstOption.Push(location3);
        _stackFirstOption.Push(location2);
        _stackFirstOption.Push(location1);
    }

    public void InitializeSecondStack()
    {
        var item1 = new Item("Genki-dama", ItemType.POWER, "Es una técnica de combate de naturaleza ofensiva que requiere una parte de la energía de todas las criaturas.");
        var question1 = new Question(QuestionConstants.Question1, QuestionConstants.Answer1, QuestionType.NO_CONFIRMATION);
        var question2 = new Question(QuestionConstants.Question2, QuestionConstants.Answer2, QuestionType.SIMPLE_SELECT);
        question2.AddOptions(["Oolong", "Puar", "Ten Ten"]);
        Boss boss1 = new Boss("Androide 16", "El Androide 16 es uno de los cíborgs creados por el Dr. Gero.", item1, 1000, 200, WildcardOption.YES);
        boss1.AddQuestion(question1);
        boss1.AddQuestion(question2);
        var location1 = new Location("Un Androide poderoso esta frente a ti.", boss1);

        var item2 = new Item("Resplandor Final", ItemType.POWER, "El ataque definitivo de Vegeta.");
        var question3 = new Question(QuestionConstants.Question3, QuestionConstants.Answer3, QuestionType.YES_CONFIRMATION);
        var question4 = new Question(QuestionConstants.Question4, QuestionConstants.Answer4, QuestionType.SIMPLE_SELECT);
        question4.AddOptions(["Mr. Satan", "Maestro Roshi", "Kamisama"]);
        var boss2 = new Boss("Androide 17", "El Androide 17 es uno de los cíborgs creados por el Dr. Gero.", item2, 1200, 300, WildcardOption.NO);
        boss2.AddQuestion(question3);
        boss2.AddQuestion(question4);
        var location2 = new Location("No te confies, tiene poder infinito.", boss2);

        var item3 = new Item("Super Saiyajin Fase 2", ItemType.VELOCITY, "Es el segundo nivel que puede alcanzar un saiyajin.");
        var question5 = new Question(QuestionConstants.Question5, QuestionConstants.Answer5, QuestionType.SIMPLE_SELECT);
        question5.AddOptions(["Resplandor Final", "Genki-dama", "Makankosappo"]);
        var question6 = new Question(QuestionConstants.Question6, QuestionConstants.Answer6, QuestionType.NO_CONFIRMATION);
        var boss3 = new Boss("Androide 18", "El Androide 18 es uno de los cíborgs creados por el Dr. Gero.", item3, 1800, 400, WildcardOption.YES);
        boss3.AddQuestion(question5);
        boss3.AddQuestion(question6);
        var location3 = new Location("No te confies en su apariencia.", boss3);

        var item4 = new Item("Super Saiyajin Fase 3", ItemType.VELOCITY, "Es el tercer nivel que puede alcanzar un saiyajin.");
        var question7 = new Question(QuestionConstants.Question7, QuestionConstants.Answer7, QuestionType.SIMPLE_SELECT);
        question7.AddOptions(["Mark", "Miguel", "Kenny"]);
        var question8 = new Question(QuestionConstants.Question8, QuestionConstants.Answer8, QuestionType.SIMPLE_SELECT);
        question8.AddOptions(["Gold Freezer", "Kid Buu", "Mr. Buu"]);
        var boss4 = new Boss("Cell Imperfecto", "Bio androide imperfecto, necesita absorver a los androides para ser perfecto.", item4, 2000, 500, WildcardOption.NO);
        boss4.AddQuestion(question7);
        boss4.AddQuestion(question8);
        var location4 = new Location("Debes evitar que Cell se alimente de todos los androides.", boss4);

        var item5 = new Item("Esferas del Dragon", ItemType.POWER, "Son 7 esferas que te ayudan a llamar a Shen Long para pedir un deseo.");
        var question9 = new Question(QuestionConstants.Question9, QuestionConstants.Answer9, QuestionType.SIMPLE_SELECT);
        question9.AddOptions(["Gohan", "Vegeta", "Goku"]);
        var question10 = new Question(QuestionConstants.Question10, QuestionConstants.Answer10, QuestionType.SIMPLE_SELECT);
        question10.AddOptions(["Mr. Satan", "Babidi", "Tao pai pai"]);
        var boss5 = new Boss("Cell Perfecto", "Bio androide creado por el Dr. Gero.", item5, 2400, 600, WildcardOption.NO);
        boss5.AddQuestion(question9);
        boss5.AddQuestion(question10);
        var location5 = new Location("No permitas que se vuelva a regenerar y destruye cada celula de su cuerpo.", boss5);

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

        Dictionary<string, Action> optionsToChoose = new Dictionary<string, Action>
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
