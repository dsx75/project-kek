using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Rulesets;

/// <summary>
/// Ruleset.
/// </summary>
public interface IRuleset
{
    /// <summary>
    /// ID of this Ruleset.
    /// <br/>
    /// Allowed values: 1, 2, 3, ...
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// World Version this Ruleset was created for.
    /// </summary>
    WorldVersion WorldVersion { get; }

    /// <summary>
    /// Name of this Ruleset.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Full path to the directory where files for this Ruleset are located.
    /// </summary>
    public string Folder { get; }
}
