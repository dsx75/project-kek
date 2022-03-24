namespace TaidanaKage.Kek.Common;

/// <summary>
/// World Versions.
/// </summary>
public enum WorldVersion
{
    /// <summary>
    /// Unknown world version.
    /// <br/>
    /// If world version hasn't been selected yet.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Vanilla.
    /// <br/>
    /// Supported.
    /// </summary>
    W1 = 1,

    /// <summary>
    /// The Burning Crussade.
    /// <br/>
    /// Supported.
    /// </summary>
    W2 = 2,

    /// <summary>
    /// Wrath of the Lich King.
    /// <br/>
    /// Supported.
    /// </summary>
    W3 = 3,

    /// <summary>
    /// Cataclysm.
    /// <br/>
    /// Supported.
    /// </summary>
    W4 = 4,

    /// <summary>
    /// Mists of Pandaria.
    /// <br/>
    /// Supported.
    /// </summary>
    W5 = 5,

    /// <summary>
    /// Unsupported world version.
    /// <br/>
    /// For all the newer clients.
    /// </summary>
    Unsupported = 999
}