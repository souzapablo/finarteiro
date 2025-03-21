namespace Finarteiro.Api.Common.Base;

public abstract class Entity<TId> where TId : Id, new()
{
    public TId Id { get; private set; } = new();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime LastUpdate { get; private set; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; } = false;

    public void Delete() 
    {
        IsDeleted = true;
        Update();
    }

    protected void Update() =>
        LastUpdate = DateTime.UtcNow;
}

public abstract class Id
{
    public Guid Value { get; private set; } = Guid.NewGuid();
}
