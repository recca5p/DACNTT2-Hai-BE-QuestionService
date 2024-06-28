using Domain.Entities.Base;

namespace Domain.Entities;

public class Subject : AuditEntity<Int32>
{
    public string Name { get; set; }
    public virtual ICollection<Chapter> Chapters { get; set; } = new HashSet<Chapter>();
}