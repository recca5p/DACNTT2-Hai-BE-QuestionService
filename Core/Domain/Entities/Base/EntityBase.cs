using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Interfaces;

namespace Domain.Entities.Base;

public abstract class EntityBase<TKey> : IEntityBase<TKey>   
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual TKey Id { get; set; }   
}   