using Domain.Entities.Base;

namespace Domain.Entities;

public class Level : AuditEntity<Int32>
{
    public string Name { get; set; }
    public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
}