using NLog;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Clients;

internal class MyClientManager : IClientManager
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private int _selectedClientId;
    private IClient? _selectedClient;

    internal MyClientManager()
    {
        _selectedClientId = 0;
        _selectedClient = null;
    }

    public IClient AddClient(string exeFile)
    {
        // Since there's a lot of code involved, a separate class was created.
        return new ClientGenerator(exeFile).Run();
    }

    public IClient? GetClient(int id)
    {
        var command = MyMeta.Conn.CreateCommand();
        command.CommandText =
            @"
            SELECT `folder`, `exe_file_name`, `version_major`, `version_minor`, `version_build`, `version_private`, `id_world_version`, `is_64_bit` 
            FROM `clients`
            WHERE `id` = $Id
            ";
        command.Parameters.AddWithValue("$Id", id);

        IClient? client = null;
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string folder = reader.GetString(reader.GetOrdinal("folder"));
                string exeFileName = reader.GetString(reader.GetOrdinal("exe_file_name"));
                int versionMajor = reader.GetInt32(reader.GetOrdinal("version_major"));
                int versionMinor = reader.GetInt32(reader.GetOrdinal("version_minor"));
                int versionBuild = reader.GetInt32(reader.GetOrdinal("version_build"));
                int versionPrivate = reader.GetInt32(reader.GetOrdinal("version_private"));

                // TODO duplicate code
                int idWorldVersion = reader.GetInt32(reader.GetOrdinal("id_world_version"));
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
                        ArgumentOutOfRangeException ex = new(nameof(idWorldVersion), idWorldVersion, "Unable to assing a World Version for this Client. Unsupported Client version?");
                        logger.Error(ex);
                        throw (ex);
                }

                int i64 = reader.GetInt32(reader.GetOrdinal("is_64_bit"));
                bool is64Bit = (i64 == 1);

                client = new MyClient(id, folder, exeFileName, versionMajor, versionMinor, versionBuild, versionPrivate, worldVersion, is64Bit);
            }
        }
        return client;
    }

    public int SelectedClientId
    {
        get
        {
            return _selectedClientId;
        }
        set
        {
            _selectedClientId = value;
            _selectedClient = null;
        }
    }

    public IClient? SelectedClient
    {
        get
        {
            return _selectedClient;
        }
    }
}