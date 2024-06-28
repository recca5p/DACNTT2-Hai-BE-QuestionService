using Domain.Entities.Base;
using Domain.Entities.Interfaces;

namespace Domain.Entities;

public class Question : AuditEntity<Int32>
{
    public string Title { get; set; }
    public string AnswerChoice { get; set; }
    public string RightAnswer { get; set; }
    public virtual Int32 QuestionTypeId { get; set; }
    public virtual Int32 LevelId { get; set; }
    public virtual Int32 ChapterId { get; set; }
    public virtual QuestionType QuestionType { get; set; }
    public virtual Level Level { get; set; }
    public virtual Chapter Chapter { get; set; }
}