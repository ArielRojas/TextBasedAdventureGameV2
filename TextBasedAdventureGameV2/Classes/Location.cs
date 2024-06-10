namespace TextBasedAdventureGameV2.Classes;

using Spectre.Console;

internal class Location
{
    public string Detail { get; set; }
    public Boss Boss { get; set; }

    public Location(string detail, Boss boss)
    {
        Detail = detail;
        Boss = boss;
    }

    public void ShowLocationInformation()
    {
        Console.WriteLine("==============================================================================================\n");
        AnsiConsole.WriteLine($"Detalle de la localidad: {Detail} \nJefe: {Boss.Name} \nDetalles del Jefe: {Boss.Description}");
        Console.WriteLine("\n==============================================================================================\n");
    }
}
