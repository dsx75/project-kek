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
}
