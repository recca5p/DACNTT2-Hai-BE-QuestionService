namespace Domain.Entities.Base;

public class QuestionType : AuditEntity<Int32>
{
    public string Name { get; set; }
    public string DisplayedTitle { get; set; }
    public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
}