using Microsoft.Data.Sqlite;
using NLog;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Rulesets;

/// <summary>
/// The whole purpose of this class is to add a new Ruleset into the Meta Database.
/// </summary>
internal class RulesetGenerator
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private readonly WorldVersion _worldVersion;
    private readonly string _name;
    private readonly string _folder;

    internal RulesetGenerator(WorldVersion worldVersion, string name, string folder)
    {
        if ((worldVersion == WorldVersion.Unknown) || (worldVersion == WorldVersion.Unsupported))
        {
            ArgumentException ex = new("Ruleset must have a valid World Version assigned.", nameof(worldVersion));
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            ArgumentException ex = new("Ruleset's name cannot be empty.", nameof(name));
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(folder))
        {
            ArgumentException ex = new("Ruleset's folder path cannot be empty.", nameof(folder));
            logger.Error(ex);
            throw (ex);
        }

        _worldVersion = worldVersion;
        _name = name;
        _folder = folder;
    }

    internal IRuleset Run()
    {
        SqliteCommand cmd = new();
        cmd.Connection = MyMeta.Conn;
        cmd.CommandText =
            @"
            INSERT INTO `rulesets`
            (`id_world_version`, `name`, `folder`) 
            VALUES 
            (@IdWorldVersion, $Name, $Folder)
            ";

        int idWorldVersion = (int)_worldVersion;
        cmd.Parameters.AddWithValue("@IdWorldVersion", idWorldVersion);

        cmd.Parameters.AddWithValue("@Name", _name);
        cmd.Parameters.AddWithValue("@Folder", _folder);

        cmd.ExecuteNonQuery();

        // Let's find the ID of newly added Ruleset
        int id = MyMeta.GetLastInsertRowId();

        return new MyRuleset(id, _worldVersion, _name, _folder);
    }
}
