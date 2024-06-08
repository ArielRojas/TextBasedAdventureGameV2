namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Enums;
using TextBasedAdventureGameV2.Interfaces;

internal class Boss : ICharacter
{
    private string _name;
    private string _description;
    private Item _item;
    private int _lifePoints;
    private int _attackPoints;
    private List<Question> questions;

    public Boss(string name, string description, Item item, int lifePoints, int attackPoints, WildcardOption wildcardOption)
    {
        _name = name;
        _description = description;
        _item = item;
        _lifePoints = lifePoints;
        _attackPoints = attackPoints;
        WildcardOption = wildcardOption;
        questions = [];
    }

    public string Name => _name;

    public int LifePoints
    {
        get => _lifePoints;
    }

    public int AttackPoints
    {
        get => _attackPoints;
    }

    public Item Item => _item;

    public WildcardOption WildcardOption { get; }

    public void InteractInGame(ICharacter character)
    {
        throw new NotImplementedException();
    }

    public int ReceiveAttack(int attack)
    {
        return _lifePoints -= attack;
    }

    public void AddQuestion(Question question)
    {
        questions.Add(question);
    }

    public Question getQuestion(int index)
    {
        return questions[index];
    }

    public bool AskQuestion(Question question)
    {
        QuestionHandler.SelectQuestionType(question, question.GetOptions().ToArray());
        CommonActions.ContinueWithGame();
        return QuestionHandler.GetAnswerStatus();
    }

    public void ShowPoints()
    {
        var pointsTable = new Table();
        pointsTable.AddColumn($"[red]{BossConstants.LifePoints} {_name}: {_lifePoints}[/]");
        pointsTable.AddRow($"[red]{BossConstants.AttackPoints} {_name}: {_attackPoints}[/]");
        AnsiConsole.Write(pointsTable);
    }

    public void VerifyAnswerIsCorrect(Player player, bool isAnswerCorrect)
    {
        if (isAnswerCorrect)
        {
            player.AnsweredQuestionsNumber++;
        }
    }
}
