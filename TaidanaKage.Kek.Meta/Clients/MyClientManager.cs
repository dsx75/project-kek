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

                int idWorldVersion = reader.GetInt32(reader.GetOrdinal("id_world_version"));
                WorldVersion worldVersion = Utils.GetWorldVersion(idWorldVersion);

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