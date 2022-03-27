using NLog;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Rulesets;

internal class MyRulesetManager : IRulesetManager
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    internal MyRulesetManager()
    {
    }

    public IRuleset AddRuleset(WorldVersion worldVersion, string name, string folder)
    {
        // Since there will be a lot of code involved (in the future), a separate class was created.
        return new RulesetGenerator(worldVersion, name, folder).Run();
    }

    public IRuleset? GetRuleset(int id)
    {
        var command = MyMeta.Conn.CreateCommand();
        command.CommandText =
            @"
            SELECT `id_world_version`, `name`, `folder`
            FROM `rulesets`
            WHERE `id` = $Id
            ";
        command.Parameters.AddWithValue("$Id", id);

        IRuleset? ruleset = null;
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int idWorldVersion = reader.GetInt32(reader.GetOrdinal("id_world_version"));
                WorldVersion worldVersion = Utils.GetWorldVersion(idWorldVersion);

                string name = reader.GetString(reader.GetOrdinal("name"));
                string folder = reader.GetString(reader.GetOrdinal("folder"));

                ruleset = new MyRuleset(id, worldVersion, name, folder);
            }
        }
        return ruleset;
    }

    public List<int> Rulesets(WorldVersion worldVersion)
    {
        var command = MyMeta.Conn.CreateCommand();
        command.CommandText =
            @"
            SELECT `id`
            FROM `rulesets`
            WHERE `id_world_version` = $IdWorldVersion
            ORDER BY `id`
            ";

        command.Parameters.AddWithValue("$IdWorldVersion", (int)worldVersion);

        List<int> rulesets = new();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                rulesets.Add(id);
            }
        }
        return rulesets;
    }
}
