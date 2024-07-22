namespace UserService.Models;

public class QuestionModel
{
    public int QuestionId { get; set; }
    public string QuestionTitle { get; set; }
    public string AnswerChoice { get; set; }
    public string RightAnswer { get; set; }
    public int QuestionTypeId { get; set; }
    public string QuestionTypeName { get; set; }
    public string DisplayedTitle { get; set; }
    public int LevelId { get; set; }
    public string LevelName { get; set; }
    public int ChapterId { get; set; }
    public string ChapterName { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string CreatedByName { get; set; }
    public long CreatedById { get; set; }
}