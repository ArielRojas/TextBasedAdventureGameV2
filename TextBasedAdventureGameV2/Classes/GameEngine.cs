namespace TextBasedAdventureGameV2.Classes;

using TextBasedAdventureGameV2.Enums;

internal class GameEngine
{
    private static List<Location> _locations = [];

    private Stack<Location> _stackFirstOption = new Stack<Location>();
    private Stack<Location> _stackSecondOption = new Stack<Location>();

    public static int GetRandomNumberToStartGame()
    {
        Random random = new Random();
        int minValue = 1;
        int maxValue = 10;

        return random.Next(minValue, maxValue);
    }

    public void InitializeFirstStack()
    {
        Item item1 = new Item("KAME HAME HA", ItemType.POWER, "Gran cantidad de energía en las manos.");
        Boss boss1 = new Boss("Rikum", "Es un villano con mucha fuerza.", item1, 1000, 200);
        Location location1 = new Location("Una Fuerza sobrehumana esta frente a ti.", boss1);

        Item item2 = new Item("Kaioken", ItemType.VELOCITY, "Es una técnica poderosa que permite a los guerreros aumentar su fuerza y velocidad temporalmente.");
        Boss boss2 = new Boss("Jheese", "Es un villano con gran velocidad.", item2, 1200, 300);
        Location location2 = new Location("Aumenta tu velocidad.", boss2);

        Item item3 = new Item("Genki-dama", ItemType.POWER, "Es una técnica de combate de naturaleza ofensiva que requiere una parte de la energía de todas las criaturas.");
        Boss boss3 = new Boss("Capitán Ginyu", "Es el lider de las Fuerzas Especiales Ginyu.", item3, 1500, 500);
        Location location3 = new Location("Cuidate de la tecnica especial del Capitan Ginyu", boss3);

        Item item4 = new Item("Super Saiyajin", ItemType.POWER, "Es el primer nivel que puede alcanzar un saiyajin.");
        Boss boss4 = new Boss("Capitán Ginyu", "Es el lider de las Fuerzas Especiales Ginyu.", item3, 1500, 500);
        Location location4 = new Location("Cuidate de la tecnica especial del Capitan Ginyu", boss3);

        _stackFirstOption.Push(location4);
        _stackFirstOption.Push(location3);
        _stackFirstOption.Push(location2);
        _stackFirstOption.Push(location1);
    }

    public void InitializeSecondStack()
    {
        Item item1 = new Item("Resplandor Final", ItemType.POWER, "El ataque definitivo de Vegeta.");
        Boss boss1 = new Boss("Androide 17", "El Androide 17 es uno de los cíborgs creados por el Dr. Gero.", item1, 1000, 200);
        Location location1 = new Location("No te confies, tiene poder infinito.", boss1);

        Item item2 = new Item("Super Saiyajin Fase 2", ItemType.VELOCITY, "Es el segundo nivel que puede alcanzar un saiyajin.");
        Boss boss2 = new Boss("Androide 18", "El Androide 18 es uno de los cíborgs creados por el Dr. Gero.", item2, 1200, 300);
        Location location2 = new Location("Debes evitar que Cell se alimente de todos los androides.", boss2);

        Item item3 = new Item("Esferas del Dragon", ItemType.POWER, "Son 7 esferas que te ayudan a llamar a Shen Long para pedir un deseo.");
        Boss boss3 = new Boss("Cell", "Bio androide creado por el Dr. Gero.", item3, 1500, 500);
        Location location3 = new Location("No permitas que se vuelva a regenerar y destruye cada celula de su cuerpo.", boss3);

        _stackSecondOption.Push(location3);
        _stackSecondOption.Push(location2);
        _stackSecondOption.Push(location1);
    }

    public void StartGame()
    {
        InitializeFirstStack();
        InitializeSecondStack();

        var rollDice = GetRandomNumberToStartGame();
        Console.WriteLine("Si el numero del dado es menor a 5 te toca la saga de Freezer, si es mayor te tocara la saga de Cell. Suerte!");
        Console.WriteLine("Lanzando el dado ........");
        Console.WriteLine($"Te salio el numero: {rollDice}");

        if (rollDice < 5)
        {
            Console.WriteLine("Te toco primero la saga de Freezer.");
            _stackFirstOption.Peek().ShowLocationInformation();
        }
        else
        {
            Console.WriteLine("Te toco primero la saga de Cell.");
            _stackSecondOption.Peek().ShowLocationInformation();
        }
    }
}
