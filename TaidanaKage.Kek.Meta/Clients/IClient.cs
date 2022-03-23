using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta;

/// <summary>
/// Client.
/// <br/>
/// This is a specific WoW client installation with all related information and data.
/// </summary>
public interface IClient
{
    /// <summary>
    /// ID of this Client.
    /// <br/>
    /// Allowed values: 1, 2, 3, ...
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Folder in which this Client is installed.
    /// <br/>
    /// <example>
    /// For example:
    /// "C:\Program Files\World of Warcraft"
    /// </example>
    /// </summary>
    string Folder { get; }

    /// <summary>
    /// This Client's executable file name.
    /// <br/>
    /// <example>
    /// For example:
    /// "WoW-64.exe"
    /// </example>
    /// </summary>
    string ExeFileName { get; }

    /// <summary>
    /// Full path to this Client's executable file.
    /// <br/>
    /// <example>
    /// For example:
    /// "C:\Program Files\World of Warcraft\WoW-64.exe"
    /// </example>
    /// </summary>
    string ExeFile { get; }

    /// <summary>
    /// Major part of this Client's version.
    /// <br/>
    /// Allowed values: 0, 1, 2, 3, ...
    /// <br/>
    /// <example>
    /// For example, for the Client 1.12.1.5875, the major part is: 1
    /// </example>
    /// </summary>
    int VersionMajor { get; }

    /// <summary>
    /// Minor part of this Client's version.
    /// <br/>
    /// Allowed values: 0, 1, 2, 3, ...
    /// <br/>
    /// <example>
    /// For example, for the Client 1.12.1.5875, the minor part is: 12 
    /// </example>
    /// </summary>
    int VersionMinor { get; }

    /// <summary>
    /// Build part of this Client's version.
    /// <br/>
    /// Allowed values: 0, 1, 2, 3, ...
    /// <br/>
    /// <example>
    /// For example, for the Client 1.12.1.5875, the build part is: 1 
    /// </example>
    /// </summary>
    int VersionBuild { get; }

    /// <summary>
    /// Private part of this Client's version.
    /// <br/>
    /// Allowed values: 0, 1, 2, 3, ...
    /// <br/>
    /// <example>
    /// For example, for the Client 1.12.1.5875, the private part is: 5875 
    /// </example>
    /// </summary>
    int VersionPrivate { get; }


    /// <summary>
    /// Full version of this Client.
    /// <br/>
    /// <example>
    /// For example: 1.12.1.5875
    /// </example>
    /// </summary>
    string Version { get; }

    /// <summary>
    /// World Version assigned to this Client.
    /// </summary>
    WorldVersion WorldVersion { get; }

    /// <summary>
    /// Is this Client 64-bit?
    /// <br/>
    /// <br/>
    /// If an installation folder contains both 32-bit and 64-bit versions of exe file,
    /// these can be stored in the Meta Database as two separate Clients.
    /// </summary>
    bool Is64Bit { get; }

    /// <summary>
    /// Changes content of this Client's realmlist.wtf file to:
    /// set realmlist 127.0.0.1:3724
    /// </summary>
    void Configure();

    /// <summary>
    /// Starts the Client.
    /// </summary>
    void Run();
}