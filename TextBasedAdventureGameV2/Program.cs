namespace TextBasedAdventureGameV2;

using TextBasedAdventureGameV2.Classes;

internal class Program
{
    static void Main(string[] args)
    {
        GameEngine gameEngine = new();
        gameEngine.PlayGame();
    }
}
