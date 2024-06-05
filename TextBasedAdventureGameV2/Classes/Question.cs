using TextBasedAdventureGameV2.Enums;

namespace TextBasedAdventureGameV2.Classes;

internal class Question
{
    public string QuestionDetail { get; }

    public string Answer { get; }

    public QuestionType QuestionType { get; }

    public Question(string questionDetail, string answer, QuestionType questionType)
    {
        QuestionDetail = questionDetail;
        Answer = answer;
        QuestionType = questionType;
    }
}
