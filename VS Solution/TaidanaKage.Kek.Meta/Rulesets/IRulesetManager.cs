using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Rulesets;

/// <summary>
/// Ruleset Manager.
/// </summary>
public interface IRulesetManager
{
    /// <summary>
    /// Adds a new Ruleset into the Meta Database.
    /// </summary>
    /// <param name="worldVersion">World Version the new Ruleset is being created for.</param>
    /// <param name="name">Name of the new Ruleset.</param>
    /// <param name="folder">Folder where files for the new Ruleset are located.</param>
    /// <returns>Newly added Ruleset.</returns>
    public IRuleset AddRuleset(WorldVersion worldVersion, string name, string folder);

    /// <summary>
    /// Gets the Ruleset with the specified ID.
    /// <br/>
    /// If no Ruleset was found, returns <c>null</c>.
    /// </summary>
    /// <param name="id">ID of the Ruleset. Must already exist in the Meta Database.</param>
    /// <returns>Ruleset or <c>null</c>.</returns>
    public IRuleset? GetRuleset(int id);

    /// <summary>
    /// Gets list of IDs of all Rulesets for the specified World Version.
    /// <br/>
    /// List is ordered by ID.
    /// </summary>
    /// <returns>List of IDs.</returns>
    public List<int> Rulesets(WorldVersion worldVersion);
}
