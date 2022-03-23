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
    /// </summary>
    /// <param name="id">ID of the Client. Must already exist in the Meta Database.</param>
    /// <returns>Client.</returns>
    public IClient GetClient(int id);

    /// <summary>
    /// ID of the Client selected by Player, or <c>0</c> if Player hasn't selected one yet.
    /// </summary>
    public int SelectedClientId { get; set; }

    /// <summary>
    /// The Client selected by Player, or <c>0</c> if Player hasn't selected one yet.
    /// </summary>
    public IClient SelectedClient { get; }
}