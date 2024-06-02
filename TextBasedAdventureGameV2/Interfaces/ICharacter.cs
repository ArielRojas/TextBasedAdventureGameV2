namespace TextBasedAdventureGameV2.Interfaces;

internal interface ICharacter
{
    string Name { get; }

    int ReceiveAttack(int attack);

    void ShowPoints();

    void InteractInGame(ICharacter character);
}
