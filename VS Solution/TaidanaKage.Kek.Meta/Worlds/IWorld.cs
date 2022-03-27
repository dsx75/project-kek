namespace TaidanaKage.Kek.Meta.Worlds;

/// <summary>
/// World.
/// <br/>
/// Each game takes place in a specific World.
/// </summary>
public interface IWorld
{
    /// <summary>
    /// ID of this World.
    /// <br/>
    /// Allowed values: 1, 2, 3, ...
    /// </summary>
    public int Id { get; }
}
