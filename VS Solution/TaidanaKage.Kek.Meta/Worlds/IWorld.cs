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
    int Id { get; }

    /// <summary>
    /// ID of the Ruleset used to create this World.
    /// </summary>
    int RulesetId { get; }

    /// <summary>
    /// Name of this World.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Full path to the file in which this World is stored.
    /// </summary>
    string File { get; }
}
