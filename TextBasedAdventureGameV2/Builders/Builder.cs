namespace TextBasedAdventureGameV2.Builders;

using TextBasedAdventureGameV2.Classes;
using TextBasedAdventureGameV2.Constants;
using TextBasedAdventureGameV2.Enums;

public static class ItemBuilder
{
    private readonly static Dictionary<int, Item> _itemsList = new()
    {
        { CommonConstants.ONE, new Item(ItemConstants.ItemDetail1, ItemConstants.ItemType1, ItemConstants.ItemDescription1) },
        { CommonConstants.TWO, new Item(ItemConstants.ItemDetail2, ItemConstants.ItemType2, ItemConstants.ItemDescription2) },
        { CommonConstants.THREE, new Item(ItemConstants.ItemDetail3, ItemConstants.ItemType3, ItemConstants.ItemDescription3) },
        { CommonConstants.FOUR, new Item(ItemConstants.ItemDetail4, ItemConstants.ItemType4, ItemConstants.ItemDescription4) },
        { CommonConstants.FIVE, new Item(ItemConstants.ItemDetail5, ItemConstants.ItemType5, ItemConstants.ItemDescription5) },
        { CommonConstants.SIX, new Item(ItemConstants.ItemDetail6, ItemConstants.ItemType6, ItemConstants.ItemDescription6) },
        { CommonConstants.SEVEN, new Item(ItemConstants.ItemDetail7, ItemConstants.ItemType7, ItemConstants.ItemDescription7) },
        { CommonConstants.EIGHT, new Item(ItemConstants.ItemDetail8, ItemConstants.ItemType8, ItemConstants.ItemDescription8) },
        { CommonConstants.NINE, new Item(ItemConstants.ItemDetail9, ItemConstants.ItemType9, ItemConstants.ItemDescription9) }
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
        { CommonConstants.ONE, new Boss(BossConstants.BossName1, BossConstants.BossDescription1, ItemBuilder.BuildItem(CommonConstants.ONE), BossConstants.BossLifePoints1, BossConstants.BossAttackPoints1, BossConstants.BossWildCardOption1) },
        { CommonConstants.TWO, new Boss(BossConstants.BossName2, BossConstants.BossDescription2, ItemBuilder.BuildItem(CommonConstants.TWO), BossConstants.BossLifePoints2, BossConstants.BossAttackPoints2, BossConstants.BossWildCardOption2) },
        { CommonConstants.THREE, new Boss(BossConstants.BossName3, BossConstants.BossDescription3, ItemBuilder.BuildItem(CommonConstants.THREE), BossConstants.BossLifePoints3, BossConstants.BossAttackPoints3, BossConstants.BossWildCardOption3) },
        { CommonConstants.FOUR, new Boss(BossConstants.BossName4, BossConstants.BossDescription4, ItemBuilder.BuildItem(CommonConstants.FOUR), BossConstants.BossLifePoints4, BossConstants.BossAttackPoints4, BossConstants.BossWildCardOption4) },
        { CommonConstants.FIVE, new Boss(BossConstants.BossName5, BossConstants.BossDescription5, ItemBuilder.BuildItem(CommonConstants.FIVE), BossConstants.BossLifePoints5, BossConstants.BossAttackPoints5, BossConstants.BossWildCardOption5) },
        { CommonConstants.SIX, new Boss(BossConstants.BossName6, BossConstants.BossDescription6, ItemBuilder.BuildItem(CommonConstants.FOUR), BossConstants.BossLifePoints6, BossConstants.BossAttackPoints6, BossConstants.BossWildCardOption6) },
        { CommonConstants.SEVEN, new Boss(BossConstants.BossName7, BossConstants.BossDescription7, ItemBuilder.BuildItem(CommonConstants.SEVEN), BossConstants.BossLifePoints7, BossConstants.BossAttackPoints7, BossConstants.BossWildCardOption7) },
        { CommonConstants.EIGHT, new Boss(BossConstants.BossName8, BossConstants.BossDescription8, ItemBuilder.BuildItem(CommonConstants.EIGHT), BossConstants.BossLifePoints8, BossConstants.BossAttackPoints8, BossConstants.BossWildCardOption8) },
        { CommonConstants.NINE, new Boss(BossConstants.BossName9, BossConstants.BossDescription9, ItemBuilder.BuildItem(CommonConstants.NINE), BossConstants.BossLifePoints9, BossConstants.BossAttackPoints9, BossConstants.BossWildCardOption9) },
        { CommonConstants.TEN, new Boss(BossConstants.BossName10, BossConstants.BossDescription10, ItemBuilder.BuildItem(CommonConstants.FIVE), BossConstants.BossLifePoints10, BossConstants.BossAttackPoints10, BossConstants.BossWildCardOption10) }
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
        { CommonConstants.ONE, new Location(LocationConstants.LocationDetail1, BossBuilder.BuildBoss(CommonConstants.ONE)) },
        { CommonConstants.TWO, new Location(LocationConstants.LocationDetail2, BossBuilder.BuildBoss(CommonConstants.TWO)) },
        { CommonConstants.THREE, new Location(LocationConstants.LocationDetail3, BossBuilder.BuildBoss(CommonConstants.THREE)) },
        { CommonConstants.FOUR, new Location(LocationConstants.LocationDetail4, BossBuilder.BuildBoss(CommonConstants.FOUR)) },
        { CommonConstants.FIVE, new Location(LocationConstants.LocationDetail5, BossBuilder.BuildBoss(CommonConstants.FIVE)) },
        { CommonConstants.SIX, new Location(LocationConstants.LocationDetail6, BossBuilder.BuildBoss(CommonConstants.SIX)) },
        { CommonConstants.SEVEN, new Location(LocationConstants.LocationDetail7, BossBuilder.BuildBoss(CommonConstants.SEVEN)) },
        { CommonConstants.EIGHT, new Location(LocationConstants.LocationDetail8, BossBuilder.BuildBoss(CommonConstants.EIGHT)) },
        { CommonConstants.NINE, new Location(LocationConstants.LocationDetail9, BossBuilder.BuildBoss(CommonConstants.NINE)) },
        { CommonConstants.TEN, new Location(LocationConstants.LocationDetail10, BossBuilder.BuildBoss(CommonConstants.TEN)) }
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
        { CommonConstants.ONE, new Question(QuestionConstants.Question1, QuestionConstants.Answer1, QuestionType.NO_CONFIRMATION, []) },
        { CommonConstants.TWO, new Question(QuestionConstants.Question2, QuestionConstants.Answer2, QuestionType.SIMPLE_SELECT, QuestionConstants.options2) },
        { CommonConstants.THREE, new Question(QuestionConstants.Question3, QuestionConstants.Answer3, QuestionType.YES_CONFIRMATION, []) },
        { CommonConstants.FOUR, new Question(QuestionConstants.Question4, QuestionConstants.Answer4, QuestionType.SIMPLE_SELECT, QuestionConstants.options4) },
        { CommonConstants.FIVE, new Question(QuestionConstants.Question5, QuestionConstants.Answer5, QuestionType.SIMPLE_SELECT, QuestionConstants.options5) },
        { CommonConstants.SIX, new Question(QuestionConstants.Question6, QuestionConstants.Answer6, QuestionType.NO_CONFIRMATION, []) },
        { CommonConstants.SEVEN, new Question(QuestionConstants.Question7, QuestionConstants.Answer7, QuestionType.SIMPLE_SELECT, QuestionConstants.options7) },
        { CommonConstants.EIGHT, new Question(QuestionConstants.Question8, QuestionConstants.Answer8, QuestionType.SIMPLE_SELECT, []) },
        { CommonConstants.NINE, new Question(QuestionConstants.Question9, QuestionConstants.Answer9, QuestionType.SIMPLE_SELECT, QuestionConstants.options9) },
        { CommonConstants.TEN, new Question(QuestionConstants.Question10, QuestionConstants.Answer10, QuestionType.SIMPLE_SELECT, QuestionConstants.options10) }
    };

    public static Question BuildQuestion(int position)
    {
        return _questionList[position];
    }
}