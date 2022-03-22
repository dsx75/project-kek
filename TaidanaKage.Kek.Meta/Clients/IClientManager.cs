namespace TaidanaKage.Kek.Meta.Clients;

/// <summary>
/// Client Manager.
/// </summary>
public interface IClientManager
{

    public IClient AddClient(string folder);

    /// <summary>
    /// Gets the Client selected by the Player, or <c>null</c> if Player hasn't selected one yet.
    /// </summary>
    public IClient? Current { get; }
}