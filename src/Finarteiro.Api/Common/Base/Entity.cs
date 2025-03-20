namespace Finarteiro.Api.Common.Base;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
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
