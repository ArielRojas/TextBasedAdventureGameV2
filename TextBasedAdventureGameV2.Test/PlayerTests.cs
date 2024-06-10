namespace TextBasedAdventureGameV2.Test;

using TextBasedAdventureGameV2.Classes;

public class PlayerTests
{
    [Fact]
    public void Player_Initilized_ShouldBeInitilizedCorrectly()
    {
        var name = "player1";
        var lifePoints = 1000;
        var attackPoints = 300;

        var player = new Player(name, lifePoints, attackPoints);

        Assert.NotNull(player);
        Assert.Equal(name, player.Name);
        Assert.Equal(lifePoints, player.LifePoints);
        Assert.Equal(attackPoints, player.AttackPoints);
    }
}
