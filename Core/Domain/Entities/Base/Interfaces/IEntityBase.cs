namespace Domain.Entities.Interfaces;

public interface IEntityBase <TKey> 
{
    TKey Id { get; set; }   
}