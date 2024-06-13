namespace TextBasedAdventureGameV2.Classes
{
    using TextBasedAdventureGameV2.Constants;

    internal static class CommonActions
    {
        public static void ContinueWithGame()
        {
            Console.WriteLine(GameConstants.PressKeyToContinueGame);
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }

        public static void StartWithTheGame()
        {
            Console.WriteLine(GameConstants.PressKeyToStartGame);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
