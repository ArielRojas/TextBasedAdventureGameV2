using TextBasedAdventureGameV2.DataStructure;
using TextBasedAdventureGameV2.Enums;

namespace TextBasedAdventureGameV2.Classes;

internal class GameEngine
{
    private static List<Location> _locations = [];

    public static int GetRandomNumberToStartGame()
    {
        Random random = new Random();
        int minValue = 1;
        int maxValue = 10;
        return random.Next(minValue, maxValue);
    }

    public static void BuildLocation()
    {
        Item item1 = new Item("KAME HAME HA", ItemType.POWER, "gran cantidad de energía en las manos.");
        Boss boss1 = new Boss("Rikum", "Es un villano con mucha fuerza.", item1, 1000, 200);
        Location location1 = new Location("Una Fuerza sobrehumana esta frente a ti.", boss1);
        _locations.Add(location1);
    }

    public static void BuildScenarios()
    {
        BuildLocation();
        var tree = new Tree<Object>()
            .Begin("Mundo de Dragonball")
                .Begin("Saga de Freezer")
                    .Begin("Fuerzas especiales Ginyu")
                        .Add(_locations[0].Detail)
                        .Add("Boter")
                        .Add("Yiz")
                    .End()
                .End()
                .Begin("Saga de Cell")
                    .Add("Androide 16")
                    .Add("Androide 17")
                    .Add("Androide 18")
                    .Add("Cell Fase 1")
                    .Add("Cell Fase 2")
                    .Add("Cell Perfecto")
                .End()
            .End();

        tree.Nodes.ForEach(p => tree.PrintNode(p, 0));
        //Console.ReadKey();
    }

    public static void StartGame()
    {
        if(GetRandomNumberToStartGame() > 5)
        {
            Console.WriteLine("Te toco la saga de Freezer.");
        }
        else
        {
            Console.WriteLine("Te toco la saga de Cell.");
        }
    }
}
