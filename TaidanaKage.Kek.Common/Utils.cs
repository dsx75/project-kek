namespace TaidanaKage.Kek.Common;

/// <summary>
/// Global helper utilities.
/// </summary>
public static class Utils
{
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
}