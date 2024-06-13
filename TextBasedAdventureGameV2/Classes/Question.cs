namespace TextBasedAdventureGameV2.Classes;

using TextBasedAdventureGameV2.Enums;

public class Question
{
    private string[] _options;

    public string QuestionDetail { get; }

    public string Answer { get; }

    public QuestionType QuestionType { get; }

    public Question(string questionDetail, string answer, QuestionType questionType, string[] options)
    {
        QuestionDetail = questionDetail;
        Answer = answer;
        QuestionType = questionType;
        _options = options;
    }

    public List<string> GetOptions()
    {
        return _options.ToList();
    }
}
