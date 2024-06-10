namespace TextBasedAdventureGameV2.Interfaces;

public interface ICharacter
{
    string Name { get; }

    int ReceiveAttack(int attack);

    void ShowPoints();

    void InteractInGame(ICharacter character);
}
