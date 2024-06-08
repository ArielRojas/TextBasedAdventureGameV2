using System.ComponentModel;
using TextBasedAdventureGameV2.Enums;

namespace TextBasedAdventureGameV2.Classes;

internal class Question
{
    private List<string> _options;

    public string QuestionDetail { get; }

    public string Answer { get; }

    public QuestionType QuestionType { get; }

    public Question(string questionDetail, string answer, QuestionType questionType)
    {
        QuestionDetail = questionDetail;
        Answer = answer;
        QuestionType = questionType;
        _options = [];
    }

    public void AddOptions(string[] options)
    {
        _options = options.ToList();
    }

    public List<string> GetOptions()
    {
        return _options;
    }
}
