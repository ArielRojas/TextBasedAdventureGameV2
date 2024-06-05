namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using System.Xml.Linq;
using TextBasedAdventureGameV2.Interfaces;

internal class Location
{
    public string Detail { get; set; }
    public Boss LocationBoss { get; set; }

    public Location(string detail, Boss boss)
    {
        Detail = detail;
        LocationBoss = boss;
    }

    public void ShowLocationInformation()
    {
        Console.WriteLine("==============================================================================================\n");
        AnsiConsole.WriteLine($"Detalle de la localidad: {Detail} \nBoss: {LocationBoss.Name}");
        Console.WriteLine("\n==============================================================================================\n");
    }
}
