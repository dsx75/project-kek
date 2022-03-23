using NLog;

namespace TaidanaKage.Kek.Common;

/// <summary>
/// Global helper utilities.
/// </summary>
public static class Utils
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Helper utility to get full path to the Meta Folder for the current Windows user.
    /// <br/>
    /// Introduced to remove duplicate code during testing.
    /// <br/>
    /// <example>
    /// For example:
    /// "C:\Users\User\AppData\Local\Taidana Kage\KeK"
    /// </example>
    /// </summary>
    /// <returns>Full path to the Meta Folder.</returns>
    public static string MetaFolder
    {
        get
        {
            string lad = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(lad, Constants.CompanyName, Constants.GameName);
        }
    }

    /// <summary>
    /// Gets the World Version for the specified ID.
    /// </summary>
    /// <param name="idWorldVersion">ID of the World Version</param>
    /// <returns>World Version</returns>
    public static WorldVersion GetWorldVersion(int idWorldVersion)
    {
        WorldVersion worldVersion;
        switch (idWorldVersion)
        {
            case 1:
                worldVersion = WorldVersion.W1;
                break;
            case 2:
                worldVersion = WorldVersion.W2;
                break;
            case 3:
                worldVersion = WorldVersion.W3;
                break;
            case 4:
                worldVersion = WorldVersion.W4;
                break;
            case 5:
                worldVersion = WorldVersion.W5;
                break;
            default:
                ArgumentOutOfRangeException ex = new(nameof(idWorldVersion), idWorldVersion, "Unable to find a World Version for this ID.");
                logger.Error(ex);
                throw (ex);
        }
        return worldVersion;
    }
}