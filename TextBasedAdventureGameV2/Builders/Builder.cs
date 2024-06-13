namespace TextBasedAdventureGameV2.Builders;

using TextBasedAdventureGameV2.Classes;
using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Enums;

public static class ItemBuilder
{
    private readonly static Dictionary<int, Item> _itemsList = new()
    {
        { 1, new Item(ItemConstants.ItemDetail1, ItemConstants.ItemType1, ItemConstants.ItemDescription1) },
        { 2, new Item(ItemConstants.ItemDetail2, ItemConstants.ItemType2, ItemConstants.ItemDescription2) },
        { 3, new Item(ItemConstants.ItemDetail3, ItemConstants.ItemType3, ItemConstants.ItemDescription3) },
        { 4, new Item(ItemConstants.ItemDetail4, ItemConstants.ItemType4, ItemConstants.ItemDescription4) },
        { 5, new Item(ItemConstants.ItemDetail5, ItemConstants.ItemType5, ItemConstants.ItemDescription5) },
        { 6, new Item(ItemConstants.ItemDetail6, ItemConstants.ItemType6, ItemConstants.ItemDescription6) },
        { 7, new Item(ItemConstants.ItemDetail7, ItemConstants.ItemType7, ItemConstants.ItemDescription7) },
        { 8, new Item(ItemConstants.ItemDetail8, ItemConstants.ItemType8, ItemConstants.ItemDescription8) },
        { 9, new Item(ItemConstants.ItemDetail9, ItemConstants.ItemType9, ItemConstants.ItemDescription9) }
    };

    public static Item BuildItem(int position)
    {
        return _itemsList[position];
    }
}

public static class BossBuilder
{
    private static readonly Dictionary<int, Boss> _bossList = new()
    {
        { 1, new Boss(BossConstants.BossName1, BossConstants.BossDescription1, ItemBuilder.BuildItem(1), BossConstants.BossLifePoints1, BossConstants.BossAttackPoints1, BossConstants.BossWildCardOption1) },
        { 2, new Boss(BossConstants.BossName2, BossConstants.BossDescription2, ItemBuilder.BuildItem(2), BossConstants.BossLifePoints2, BossConstants.BossAttackPoints2, BossConstants.BossWildCardOption2) },
        { 3, new Boss(BossConstants.BossName3, BossConstants.BossDescription3, ItemBuilder.BuildItem(3), BossConstants.BossLifePoints3, BossConstants.BossAttackPoints3, BossConstants.BossWildCardOption3) },
        { 4, new Boss(BossConstants.BossName4, BossConstants.BossDescription4, ItemBuilder.BuildItem(4), BossConstants.BossLifePoints4, BossConstants.BossAttackPoints4, BossConstants.BossWildCardOption4) },
        { 5, new Boss(BossConstants.BossName5, BossConstants.BossDescription5, ItemBuilder.BuildItem(5), BossConstants.BossLifePoints5, BossConstants.BossAttackPoints5, BossConstants.BossWildCardOption5) },
        { 6, new Boss(BossConstants.BossName6, BossConstants.BossDescription6, ItemBuilder.BuildItem(4), BossConstants.BossLifePoints6, BossConstants.BossAttackPoints6, BossConstants.BossWildCardOption6) },
        { 7, new Boss(BossConstants.BossName7, BossConstants.BossDescription7, ItemBuilder.BuildItem(7), BossConstants.BossLifePoints7, BossConstants.BossAttackPoints7, BossConstants.BossWildCardOption7) },
        { 8, new Boss(BossConstants.BossName8, BossConstants.BossDescription8, ItemBuilder.BuildItem(8), BossConstants.BossLifePoints8, BossConstants.BossAttackPoints8, BossConstants.BossWildCardOption8) },
        { 9, new Boss(BossConstants.BossName9, BossConstants.BossDescription9, ItemBuilder.BuildItem(9), BossConstants.BossLifePoints9, BossConstants.BossAttackPoints9, BossConstants.BossWildCardOption9) },
        { 10, new Boss(BossConstants.BossName10, BossConstants.BossDescription10, ItemBuilder.BuildItem(5), BossConstants.BossLifePoints10, BossConstants.BossAttackPoints10, BossConstants.BossWildCardOption10) }
    };

    public static Boss BuildBoss(int position)
    {
        return _bossList[position];
    }
}

public static class LocationBuilder
{
    private static readonly Dictionary<int, Location> _locationList = new()
    {
        { 1, new Location(LocationConstants.LocationDetail1, BossBuilder.BuildBoss(1)) },
        { 2, new Location(LocationConstants.LocationDetail2, BossBuilder.BuildBoss(2)) },
        { 3, new Location(LocationConstants.LocationDetail3, BossBuilder.BuildBoss(3)) },
        { 4, new Location(LocationConstants.LocationDetail4, BossBuilder.BuildBoss(4)) },
        { 5, new Location(LocationConstants.LocationDetail5, BossBuilder.BuildBoss(5)) },
        { 6, new Location(LocationConstants.LocationDetail6, BossBuilder.BuildBoss(6)) },
        { 7, new Location(LocationConstants.LocationDetail7, BossBuilder.BuildBoss(7)) },
        { 8, new Location(LocationConstants.LocationDetail8, BossBuilder.BuildBoss(8)) },
        { 9, new Location(LocationConstants.LocationDetail9, BossBuilder.BuildBoss(9)) },
        { 10, new Location(LocationConstants.LocationDetail10, BossBuilder.BuildBoss(10)) }
    };

    public static Location BuildLocation(int position)
    {
        return _locationList[position];
    }
}

public static class QuestionBuilder
{
    private static Dictionary<int, Question> _questionList = new()
    {
        { 1, new Question(QuestionConstants.Question1, QuestionConstants.Answer1, QuestionType.NO_CONFIRMATION, []) },
        { 2, new Question(QuestionConstants.Question2, QuestionConstants.Answer2, QuestionType.SIMPLE_SELECT, QuestionConstants.options2) },
        { 3, new Question(QuestionConstants.Question3, QuestionConstants.Answer3, QuestionType.YES_CONFIRMATION, []) },
        { 4, new Question(QuestionConstants.Question4, QuestionConstants.Answer4, QuestionType.SIMPLE_SELECT, QuestionConstants.options4) },
        { 5, new Question(QuestionConstants.Question5, QuestionConstants.Answer5, QuestionType.SIMPLE_SELECT, QuestionConstants.options5) },
        { 6, new Question(QuestionConstants.Question6, QuestionConstants.Answer6, QuestionType.NO_CONFIRMATION, []) },
        { 7, new Question(QuestionConstants.Question7, QuestionConstants.Answer7, QuestionType.SIMPLE_SELECT, QuestionConstants.options7) },
        { 8, new Question(QuestionConstants.Question8, QuestionConstants.Answer8, QuestionType.SIMPLE_SELECT, []) },
        { 9, new Question(QuestionConstants.Question9, QuestionConstants.Answer9, QuestionType.SIMPLE_SELECT, QuestionConstants.options9) },
        { 10, new Question(QuestionConstants.Question10, QuestionConstants.Answer10, QuestionType.SIMPLE_SELECT, QuestionConstants.options10) }
    };

    public static Question BuildQuestion(int position)
    {
        return _questionList[position];
    }
}