namespace Finarteiro.Api.Common.Base;

public abstract class Entity
{
    public long Id { get; private set; }
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
