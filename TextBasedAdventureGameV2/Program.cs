namespace TextBasedAdventureGameV2;

using TextBasedAdventureGameV2.DataStructure;

internal class Program
{
    static void Main(string[] args)
    {
        var tree = new Tree<string>()
            .Begin("Mundo de Dragonball")
                .Begin("Saga de Freezer")
                    .Begin("Fuerzas especiales Guiniu")
                        .Add("Ricum")
                        .Add("Botter")
                        .Add("Rojo")
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
