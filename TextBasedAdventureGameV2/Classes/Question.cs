namespace TextBasedAdventureGameV2.Classes;

internal class Question
{
    public string QuestionDetail { get; }

    public string Answer { get; }

    public Question(string questionDetail, string answer)
    {
        QuestionDetail = questionDetail;
        Answer = answer;
    }
}
