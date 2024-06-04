﻿namespace TextBasedAdventureGameV2.Classes;

using TextBasedAdventureGameV2.DataStructure;

internal class Program
{
    static void Main(string[] args)
    {
        GameEngine.BuildScenarios();
        GameEngine.StartGame();
    }


}