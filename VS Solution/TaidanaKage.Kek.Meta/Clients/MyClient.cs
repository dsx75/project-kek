using NLog;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Clients;

internal class MyClient : IClient
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private readonly int _id;
    private readonly string _folder;
    private readonly string _exeFileName;
    private readonly string _exeFile;
    private readonly int _versionMajor;
    private readonly int _versionMinor;
    private readonly int _versionBuild;
    private readonly int _versionPrivate;
    private readonly string _version;
    private readonly WorldVersion _worldVersion;
    private readonly bool _is64Bit;

    internal MyClient(int id, string folder, string exeFileName, int versionMajor, int versionMinor, int versionBuild, int versionPrivate, WorldVersion worldVersion, bool is64Bit)
    {
        // Are these checks here necessary? Eh, whatever. Better be safe than sorry.
        if (id < 1)
        {
            ArgumentOutOfRangeException ex = new(nameof(id), id, "Invalid Client ID.");
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(folder))
        {
            ArgumentException ex = new("Client's installation path cannot be empty.", nameof(folder));
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(exeFileName))
        {
            ArgumentException ex = new("Cllient's exe file name cannot be empty.", nameof(exeFileName));
            logger.Error(ex);
            throw (ex);
        }
        if (versionMajor < 0)
        {
            ArgumentOutOfRangeException ex = new(nameof(versionMajor), versionMajor, "Invalid major part of the Client's version.");
            logger.Error(ex);
            throw (ex);
        }
        if (versionMinor < 0)
        {
            ArgumentOutOfRangeException ex = new(nameof(versionMinor), versionMinor, "Invalid minor part of the Client's version.");
            logger.Error(ex);
            throw (ex);
        }
        if (versionBuild < 0)
        {
            ArgumentOutOfRangeException ex = new(nameof(versionBuild), versionBuild, "Invalid build part of the Client's version.");
            logger.Error(ex);
            throw (ex);
        }
        if (versionPrivate < 0)
        {
            ArgumentOutOfRangeException ex = new(nameof(versionPrivate), versionPrivate, "Invalid private part of the Client's version.");
            logger.Error(ex);
            throw (ex);
        }

        _id = id;
        _folder = folder;
        _exeFileName = exeFileName;
        _exeFile = Path.Combine(folder, exeFileName);
        _versionMajor = versionMajor;
        _versionMinor = versionMinor;
        _versionBuild = versionBuild;
        _versionPrivate = versionPrivate;
        _version = _versionMajor + "." + _versionMinor + "." + _versionBuild + " (" + _versionPrivate + ")";
        _worldVersion = worldVersion;
        _is64Bit = is64Bit;
    }

    public int Id => _id;

    public string Folder => _folder;

    public string ExeFileName => _exeFileName;

    public string ExeFile => _exeFile;

    public int VersionMajor => _versionMajor;

    public int VersionMinor => _versionMinor;

    public int VersionBuild => _versionBuild;

    public int VersionPrivate => _versionPrivate;

    public WorldVersion WorldVersion => _worldVersion;

    public bool Is64Bit => _is64Bit;

    public string Version => _version;

    public void Configure()
    {
        // TODO
        throw new NotImplementedException();
    }

    public void Run()
    {
        // TODO
        throw new NotImplementedException();
    }
}