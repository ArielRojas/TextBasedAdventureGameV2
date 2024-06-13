namespace TextBasedAdventureGameV2.Classes;

using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Enums;

public class Level
{
    private Player _player;
    private Boss _boss;
    private Location _location;
    private Item _item;

    public Level(Player player, Boss boss, Location location, Item item)
    {
        _player = player;
        _boss = boss;
        _location = location;
        _item = item;
    }

    public void InteractInGame(int level)
    {
        _player.AnsweredQuestionsNumber = 0;
        var recoverLifePoints = 0;
        _location.ShowLocationInformation();
        _boss.VerifyAnswerIsCorrect(_player, _boss.AskQuestion(_boss.getQuestion(0)));
        _boss.VerifyAnswerIsCorrect(_player, _boss.AskQuestion(_boss.getQuestion(1)));
        _boss.ShowPoints();
        _player.ShowPoints();
        _player.ShowInformation(PlayerConstants.DisplayItems, PlayerConstants.DisplayLifeAndAttackPoints, PlayerConstants.ContinueWithGame);
        _player.IncreasePower(_player.SelectItemToFight());
        _player.ShowPoints();
        while (_boss.LifePoints > 0 && _player.LifePoints > 0)
        {
            _player.InteractInGame(_boss);
            if (_boss.LifePoints <= 0)
            {
                break;
            }
            _boss.InteractInGame(_player);
            recoverLifePoints += _boss.AttackPoints;
        }

        if (_player.LifePoints > 0)
        {
            Console.WriteLine($"Felicidades!!!, lograste vencer a {_boss.Name}.");
            Console.WriteLine($"Ganaste el item: {_item.Name}");
            _player.AddItem(_item);
            _player.LifePoints += recoverLifePoints;
            CommonActions.ContinueWithGame();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Perdiste, la siguiente vez lo haras mejor.");
        }
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
