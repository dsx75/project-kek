namespace TaidanaKage.Kek.Meta.Clients;

/// <summary>
/// Client Manager.
/// </summary>
public interface IClientManager
{
    /// <summary>
    /// Adds a new Client installation into the Meta Database.
    /// <br/>
    /// <br/>
    /// If an installation folder contains both 32-bit and 64-bit versions of exe file,
    /// these can be stored in the Meta Database as two separate Clients.
    /// </summary>
    /// <param name="exeFile">
    /// Full path to the Client's exe file.
    /// <br/>
    /// <example>
    /// For example:
    /// "C:\Program Files\World of Warcraft\WoW-64.exe"
    /// </example>
    /// </param>
    /// <returns>Newly inserted Client.</returns>
    public IClient AddClient(string exeFile);

    /// <summary>
    /// Gets the Client with the specified ID.
    /// <br/>
    /// If no Client was found, returns <c>null</c>.
    /// </summary>
    /// <param name="id">ID of the Client. Must already exist in the Meta Database.</param>
    /// <returns>Client or <c>null</c>.</returns>
    public IClient? GetClient(int id);

    /// <summary>
    /// Gets list od IDs, one for each Client defined in the database.
    /// <br/>
    /// List is ordered by ID.
    /// </summary>
    /// <returns>List of IDs.</returns>
    public List<int> Clients();
}
