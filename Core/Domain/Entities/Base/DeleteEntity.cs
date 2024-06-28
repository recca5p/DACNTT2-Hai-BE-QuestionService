using Domain.Entities.Interfaces;

namespace Domain.Entities.Base;

public abstract class DeleteEntity<TKey> : EntityBase<TKey>, IDeleteEntity<TKey>
{
    public Boolean IsDeleted { get; set; } = false;
}   