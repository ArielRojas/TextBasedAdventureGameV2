namespace TextBasedAdventureGameV2.Test;

using TextBasedAdventureGameV2.Classes;
using TextBasedAdventureGameV2.Enums;

public class ItemTests
{
    [Fact]
    public void Item_Initialized_ShouldBeInitializedCorrectly()
    {
        var name = "Item1";
        var type = ItemType.POWER;
        var description = "description";

        var item = new Item(name, type, description);

        Assert.NotNull(item);
        Assert.Equal(name, item.Name);
        Assert.Equal(type, item.Type);
        Assert.Equal(description, item.Description);
    }
}
