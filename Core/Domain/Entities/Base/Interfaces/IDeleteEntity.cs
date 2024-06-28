namespace Domain.Entities.Interfaces;

public interface IDeleteEntity
{
    Boolean IsDeleted { get; set; }
}

public interface IDeleteEntity<TKey> : IDeleteEntity, IEntityBase<TKey>   
{   
}   