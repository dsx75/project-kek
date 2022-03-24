using TaidanaKage.Kek.Common;
using TaidanaKage.Kek.Meta.Clients;
using TaidanaKage.Kek.Meta.Rulesets;
using TaidanaKage.Kek.Meta.Worlds;

namespace TaidanaKage.Kek.Meta.Selected;

/// <summary>
/// A central place to access all things selected by the Player (if any).
/// </summary>
public interface ISelected
{
    /// <summary>
    /// Client selected by the Player.
    /// <br/>
    /// If Client hasn't been selected yet, returns: <c>null</c>
    /// </summary>
    IClient? Client { get; set; }

    /// <summary>
    /// World Version selected by the Player.
    /// <br/>
    /// World Version cannot be assigned directly, only by selecting a Client.
    /// <br/>
    /// If World Version hasn't been selected yet, returns: Unknown
    /// <br/>
    /// If an unsupported World Version was selected, returns: Unsupported
    /// </summary>
    WorldVersion WorldVersion { get; }

    /// <summary>
    /// Ruleset selected by the Player.
    /// <br/>
    /// If Ruleset hasn't been selected yet, returns: <c>null</c>
    /// </summary>
    IRuleset? Ruleset { get; set; }

    /// <summary>
    /// World selected by the Player.
    /// <br/>
    /// If World hasn't been selected yet, returns: <c>null</c>
    /// </summary>
    IWorld? World { get; set; }
}