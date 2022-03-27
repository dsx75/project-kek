namespace TaidanaKage.Kek.Meta;

/// <summary>
/// Player Account.
/// <br/>
/// To be used in the WoW client to authenticate the player.
/// </summary>
public interface IAccount
{
    /// <summary>
    /// ID of this Account.
    /// <br/>
    /// Allowed values: 1, 2, 3, ...
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Password.
    /// </summary>
    string Password { get; }

    /// <summary>
    /// Does this Account have access to special functionality.
    /// </summary>
    bool IsDeveloper { get; }
}
