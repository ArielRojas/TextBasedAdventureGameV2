namespace TextBasedAdventureGameV2.Test;

using TextBasedAdventureGameV2.Classes;
using TextBasedAdventureGameV2.Enums;

public class QuestionTests
{
    [Fact]
    public void Question_Initilized_ShouldBeInitializedCorrectly()
    {
        var questionDetail = "question detail";
        var answer = "answer1";
        var questionType = QuestionType.SIMPLE_SELECT;

        var question = new Question(questionDetail, answer, questionType);

        Assert.NotNull(question);
        Assert.Equal(questionDetail, question.QuestionDetail);
        Assert.Equal(answer, question.Answer);
        Assert.Equal(questionType, question.QuestionType);
    }
}
