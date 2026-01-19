namespace GIS.API.Abstractions;

public abstract class DomainEntity<TKey>
{
    public virtual TKey Id { get; set; } = default!;
    public bool IsTransient()
    {
        //return Id.Equals(default(TKey));
        return EqualityComparer<TKey>.Default.Equals(Id, default!);

    }
}