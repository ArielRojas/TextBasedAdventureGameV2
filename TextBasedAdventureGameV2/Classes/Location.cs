namespace TextBasedAdventureGameV2.Classes;

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
}
