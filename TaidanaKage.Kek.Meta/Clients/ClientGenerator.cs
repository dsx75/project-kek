using Microsoft.Data.Sqlite;
using NLog;
using System.Diagnostics;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Clients;

/// <summary>
/// If there's a valid WoW client installation in the specified Folder, adds this Client into the Meta Database.
/// </summary>
internal class ClientGenerator
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private readonly string _exeFile;
    private readonly string _folder;
    private readonly string _exeFileName;
    private readonly int _versionMajor;
    private readonly int _versionMinor;
    private readonly int _versionBuild;
    private readonly int _versionPrivate;
    private readonly WorldVersion _worldVersion;
    private readonly bool _is64Bit;

    internal ClientGenerator(string exeFile)
    {
        if (string.IsNullOrWhiteSpace(exeFile))
        {
            ArgumentException ex = new("Path to the new Client exe file cannot be empty.", nameof(exeFile));
            logger.Error(ex);
            throw (ex);
        }

        if (!File.Exists(exeFile))
        {
            FileNotFoundException ex = new("Client exe was not found at the specified place.", exeFile);
            logger.Error(ex);
            throw (ex);
        }

        _exeFile = exeFile;

        string? path = Path.GetDirectoryName(exeFile);
        if (string.IsNullOrWhiteSpace(path))
        {
            ArgumentException ex = new("Path to the Client exe file seems to be invalid.", nameof(exeFile));
            logger.Error(ex);
            throw (ex);
        }

        _folder = path;

        _exeFileName = Path.GetFileName(exeFile);

        FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(exeFile);
        _versionMajor = fileVersionInfo.FileMajorPart;
        _versionMinor = fileVersionInfo.FileMinorPart;
        _versionBuild = fileVersionInfo.FileBuildPart;
        _versionPrivate = fileVersionInfo.FilePrivatePart;

        switch (_versionMajor)
        {
            case 1:
                _worldVersion = WorldVersion.W1;
                break;
            case 2:
                _worldVersion = WorldVersion.W2;
                break;
            case 3:
                _worldVersion = WorldVersion.W3;
                break;
            case 4:
                _worldVersion = WorldVersion.W4;
                break;
            case 5:
                _worldVersion = WorldVersion.W5;
                break;
            default:
                ArgumentOutOfRangeException ex = new(nameof(_versionMajor), _versionMajor, "Unable to assing a World Version for this Client. Unsupported Client version?");
                logger.Error(ex);
                throw (ex);
        }

        // TODO
        _is64Bit = false;
    }

    internal IClient Run()
    {
        SqliteCommand cmd = new();
        cmd.Connection = MyMeta.Conn;
        cmd.CommandText = @"INSERT INTO `clients`
            (`folder`, `exe_file_name`, `version_major`, `version_minor`, `version_build`, `version_private`, `id_world_version`, `is_64_bit`) 
            VALUES 
            (@Folder, @ExeFileName, @VersionMajor, @VersionMinor, @VersionBuild, @VersionPrivate, @IdWorldVersion, @Is64Bit)";

        cmd.Parameters.AddWithValue("@Folder", _folder);
        cmd.Parameters.AddWithValue("@ExeFileName", _exeFileName);
        cmd.Parameters.AddWithValue("@VersionMajor", _versionMajor);
        cmd.Parameters.AddWithValue("@VersionMinor", _versionMinor);
        cmd.Parameters.AddWithValue("@VersionBuild", _versionBuild);
        cmd.Parameters.AddWithValue("@VersionPrivate", _versionPrivate);

        int idWorldVersion = (int)_worldVersion;
        cmd.Parameters.AddWithValue("@IdWorldVersion", idWorldVersion);

        int is64 = _is64Bit ? 1 : 0;
        cmd.Parameters.AddWithValue("@Is64Bit", is64);

        cmd.ExecuteNonQuery();

        // Let's find the ID of newly added Client
        // TODO Move this into a separate helper method.
        cmd.CommandText = @"SELECT last_insert_rowid()";
        var result = cmd.ExecuteScalar();
        if (result == null)
        {
            // Something went wrong
            Exception ex = new("Unable to determine ID of the newly added Client.");
            logger.Error(ex);
            throw ex;
        }
        Int64 id64 = (Int64)result;
        int id = Convert.ToInt32(id64);

        return new MyClient(id, _folder, _exeFileName, _versionMajor, _versionMinor, _versionBuild, _versionPrivate, _worldVersion, _is64Bit);
    }
}