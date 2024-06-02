namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Interfaces;
internal class Player : ICharacter
{
    private readonly string _name;
    private List<Item> _itemsList;
    private int _lifePoints;
    public int AttackPoints { get; set; }
    public int AnsweredQuestionsNumber { get; set; }

    public Player(string name, int lifePoints, int attackPoints)
    {
        _name = name;
        _lifePoints = lifePoints;
        AttackPoints = attackPoints;
        AnsweredQuestionsNumber = 0;
        _itemsList = [];
    }
    public string Name => _name;

    public int ReceiveAttack(int attack)
    {
        return _lifePoints -= attack;
    }

    public void AddItem(Item item)
    {
        _itemsList.Add(item);
    }

    public void ShowPoints()
    {
        var pointsTable = new Table();
        pointsTable.AddColumn($"[green]{Constants.PlayerLifePoints} {_lifePoints}[/]");
        pointsTable.AddRow($"[green]{Constants.PlayerAttackPoints} {AttackPoints}[/]");
        AnsiConsole.Write(pointsTable);
    }

    public void ShowInformation(params string[] options)
    {
        var showInformation = true;

        while (showInformation)
        {
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title($"[green]{Constants.PlayerInformation}[/]")
            .AddChoices(options));

            Dictionary<string, Action> actions = new Dictionary<string, Action>
            {
                {options[0], ShowItemsOnTable},
                {options[1], ShowPoints},
                {options[2], () => showInformation = false}
            };

            actions[option]();
        }
    }

    public void InteractInGame(ICharacter character)
    {
        throw new NotImplementedException();
    }

    private void ShowItemsOnTable()
    {
        var table = new Table();

        AnsiConsole.WriteLine($"\n{Constants.PlayerItems}");
        table.AddColumn(Constants.Item);
        table.AddColumn(Constants.Descripcion);
        table.AddColumn(Constants.Tipo);

        _itemsList.ForEach(item => table.AddRow(item.Name, item.Description, item.Type.ToString()));

        AnsiConsole.Write(table);
    }
}
