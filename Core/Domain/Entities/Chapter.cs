using Domain.Entities.Base;

namespace Domain.Entities;

public class Chapter : AuditEntity<Int32>
{
    public string Name { get; set; }
    public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    public virtual Int32 SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
}