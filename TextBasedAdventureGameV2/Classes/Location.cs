namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;
using System.Xml.Linq;
using TextBasedAdventureGameV2.Interfaces;

internal class Location
{
    public string Detail { get; set; }
    public ICharacter Character { get; set; }

    public Location(string detail, ICharacter character)
    {
        Detail = detail;
        Character = character;
    }

    public void ShowLocationInformation()
    {
        Console.WriteLine("==============================================================================================\n");
        AnsiConsole.WriteLine($"Detalle de la localidad: {Detail} \nBoss: {Character.Name}");
        Console.WriteLine("\n==============================================================================================\n");
    }
}
