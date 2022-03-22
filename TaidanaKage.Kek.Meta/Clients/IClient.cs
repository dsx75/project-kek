using System.Diagnostics;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta
{
    /// <summary>
    /// WoW client
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Folder in which the client is installed.
        /// <br/>
        /// <example>
        /// For example:
        /// "C:\Program Files\World of Warcraft"
        /// </example>
        /// </summary>
        string Folder { get; }

        /// <summary>
        /// Full path to the executable file.
        /// <br/>
        /// <example>
        /// For example:
        /// "C:\Program Files\World of Warcraft\WoW.exe"
        /// </example>
        /// </summary>
        string ExeFile { get; }

        /// <summary>
        /// Client version.
        /// </summary>
        FileVersionInfo ClientVersion { get; }

        /// <summary>
        /// World version supported by this client.
        /// </summary>
        WorldVersion WorldVersion { get; }

        /// <summary>
        /// Changes content of the realmlist.wtf file to
        /// "set realmlist 127.0.0.1:3724"
        /// </summary>
        void Configure();

        /// <summary>
        /// Start the client.
        /// </summary>
        void Run();
    }
}