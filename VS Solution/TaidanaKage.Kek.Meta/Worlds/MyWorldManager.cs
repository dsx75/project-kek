using NLog;
using TaidanaKage.Kek.Meta.Rulesets;

namespace TaidanaKage.Kek.Meta.Worlds;

internal class MyWorldManager : IWorldManager
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    internal MyWorldManager()
    {
    }

    public IWorld AddWorld(IRuleset ruleset, string name, string file)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            ArgumentException ex = new("World name cannot be empty.", nameof(name));
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(file))
        {
            ArgumentException ex = new("World file cannot be empty.", nameof(file));
            logger.Error(ex);
            throw (ex);
        }

        //TODO Implement actual creation of world.db database for the new World

        var cmd = MyMeta.Conn.CreateCommand();
        cmd.CommandText =
            @"
            INSERT INTO `worlds` (`id_ruleset`, `name`, `file`)
            VALUES ($IdRuleset, $Name, $File)
            ";

        cmd.Parameters.AddWithValue("$IdRuleset", ruleset.Id);
        cmd.Parameters.AddWithValue("$Name", name);
        cmd.Parameters.AddWithValue("$File", file);

        cmd.ExecuteNonQuery();

        // Let's find the ID of newly added Account
        int id = MyMeta.GetLastInsertRowId();

        return new MyWorld(id, ruleset.Id, name, file);
    }

    public IWorld? GetWorld(int id)
    {
        var command = MyMeta.Conn.CreateCommand();
        command.CommandText =
            @"
            SELECT `id_ruleset`, `name`, `file`
            FROM `worlds`
            WHERE `id` = $Id
            ";
        command.Parameters.AddWithValue("$Id", id);

        IWorld? world = null;
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int idRuleset = reader.GetInt32(reader.GetOrdinal("id_ruleset"));

                string name = reader.GetString(reader.GetOrdinal("name"));
                string file = reader.GetString(reader.GetOrdinal("file"));

                world = new MyWorld(id, idRuleset, name, file);
            }
        }
        return world;
    }

    public List<int> Worlds(IRuleset ruleset)
    {
        var command = MyMeta.Conn.CreateCommand();
        command.CommandText =
            @"
            SELECT `id`
            FROM `worlds`
            WHERE `id_ruleset` = $IdRuleset
            ORDER BY `id`
            ";

        command.Parameters.AddWithValue("$IdRuleset", ruleset.Id);

        List<int> worlds = new();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                worlds.Add(id);
            }
        }
        return worlds;
    }
}
