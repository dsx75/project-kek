using TaidanaKage.Kek.Meta.Rulesets;

namespace TaidanaKage.Kek.Meta.Worlds;

/// <summary>
/// World Manager.
/// </summary>
public interface IWorldManager
{
    /// <summary>
    /// Adds a new World into the Meta Database.
    /// </summary>
    /// <param name="ruleset">Ruleset of the new World.</param>
    /// <param name="name">Name of the new World.</param>
    /// <param name="file">Full path to the File in which the new World will be stored.</param>
    /// <returns>Newly added World.</returns>
    public IWorld AddWorld(IRuleset ruleset, string name, string file);

    /// <summary>
    /// Gets the World with the specified ID.
    /// <br/>
    /// If no World was found, returns <c>null</c>.
    /// </summary>
    /// <param name="id">ID of the World. Must already exist in the Meta Database.</param>
    /// <returns>World or <c>null</c>.</returns>
    public IWorld? GetWorld(int id);

    /// <summary>
    /// Gets list of IDs of all Worlds for the specified Ruleset.
    /// <br/>
    /// List is ordered by ID.
    /// </summary>
    /// <returns>List of IDs.</returns>
    public List<int> Worlds(IRuleset ruleset);
}
