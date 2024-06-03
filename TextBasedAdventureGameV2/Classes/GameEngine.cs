using TextBasedAdventureGameV2.DataStructure;

namespace TextBasedAdventureGameV2.Classes;

internal static class GameEngine
{
    public static void BuildScenarios()
    {
        var tree = new Tree<Object>()
            .Begin("Mundo de Dragonball")
                .Begin("Saga de Freezer")
                    .Begin("Fuerzas especiales Ginyu")
                        .Add(new Location("Una Fuerza sobrehumana esta frente a ti.", new Boss("Rikum", "", null, 1000, 200)))
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
        Console.ReadKey();
    }
}
