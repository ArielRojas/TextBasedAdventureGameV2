namespace TextBasedAdventureGameV2.Test;

using TextBasedAdventureGameV2.Classes;
using TextBasedAdventureGameV2.Enums;

public class BossTests
{
    [Fact]
    public void Boss_Initialized_ShouldBeInitializedCorrectly()
    {
        var name = "boss1";
        var description = "description";
        var item = new Item("item1", ItemType.POWER, "desc1");
        var lifePoints = 1000;
        var attackPoints = 200;
        var wildCardOption = WildcardOption.YES;

        var boss = new Boss(name, description, item, lifePoints, attackPoints, wildCardOption);

        Assert.NotNull(boss);
        Assert.Equal(name, boss.Name);
        Assert.Equal(description, boss.Description);
        Assert.Equal(item, boss.Item);
        Assert.Equal(lifePoints, boss.LifePoints);
        Assert.Equal(attackPoints, boss.AttackPoints);
        Assert.Equal(wildCardOption, boss.WildcardOption);
    }
}
