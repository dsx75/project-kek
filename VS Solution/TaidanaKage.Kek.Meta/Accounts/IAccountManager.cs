namespace TaidanaKage.Kek.Meta.Accounts;

/// <summary>
/// Account Manager.
/// </summary>
public interface IAccountManager
{
    /// <summary>
    /// Adds a new Account into the Meta Database.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="password">Password.</param>
    /// <param name="isDeveloper">Should this Account have access to special functionality?</param>
    /// <returns>Newly added Account.</returns>
    IAccount AddAccount(string name, string password, bool isDeveloper);

    /// <summary>
    /// Gets the Account with the specified ID.
    /// <br/>
    /// If no Account was found, returns <c>null</c>.
    /// </summary>
    /// <param name="id">ID of the Account. Must already exist in the Meta Database.</param>
    /// <returns>Account or <c>null</c>.</returns>
    IAccount? GetAccount(int id);

    /// <summary>
    /// Gets list of IDs of all Accounts.
    /// <br/>
    /// List is ordered by ID.
    /// </summary>
    /// <returns>List of IDs.</returns>
    List<int> Accounts();
}