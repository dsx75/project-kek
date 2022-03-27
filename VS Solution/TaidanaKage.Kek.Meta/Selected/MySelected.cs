using Microsoft.Data.Sqlite;
using TaidanaKage.Kek.Common;
using TaidanaKage.Kek.Meta.Clients;
using TaidanaKage.Kek.Meta.Rulesets;
using TaidanaKage.Kek.Meta.Worlds;

namespace TaidanaKage.Kek.Meta.Selected;

internal class MySelected : ISelected
{
    private IClient? _client;
    private WorldVersion _worldVersion;
    private IRuleset? _ruleset;
    private IWorld? _world;

    internal MySelected(IClient? client, WorldVersion worldVersion, IRuleset? ruleset, IWorld? world)
    {
        _client = client;
        _worldVersion = worldVersion;
        _ruleset = ruleset;
        _world = world;
    }

    public IClient? Client
    {
        get
        {
            return _client;
        }
        set
        {
            _client = value;

            SqliteCommand cmd = new();
            cmd.Connection = MyMeta.Conn;
            cmd.CommandText =
                @"
                UPDATE `selected`
                SET `id_client` = @IdClient, `id_world_version` = @IdWorldversion
                WHERE `id` = 1
                ";

            var parameterIdClient = new SqliteParameter("@IdClient", SqliteType.Integer);
            parameterIdClient.IsNullable = true;

            var parameterIdWorldVersion = new SqliteParameter("@IdWorldVersion", SqliteType.Integer);
            parameterIdWorldVersion.IsNullable = true;

            if (_client == null)
            {
                _worldVersion = WorldVersion.Unknown;
                parameterIdClient.Value = DBNull.Value;
                parameterIdWorldVersion.Value = DBNull.Value;
            }
            else
            {
                _worldVersion = _client.WorldVersion;
                parameterIdClient.Value = _client.Id;
                parameterIdWorldVersion.Value = (int)_worldVersion;
            }

            cmd.ExecuteNonQuery();
        }
    }

    public WorldVersion WorldVersion => _worldVersion;

    public IRuleset? Ruleset
    {
        get
        {
            return _ruleset;
        }
        set
        {
            _ruleset = value;

            SqliteCommand cmd = new();
            cmd.Connection = MyMeta.Conn;
            cmd.CommandText =
                @"
                UPDATE `selected`
                SET `id_ruleset` = @IdRuleset
                WHERE `id` = 1
                ";

            var parameterIdRuleset = new SqliteParameter("@IdRuleset", SqliteType.Integer);
            parameterIdRuleset.IsNullable = true;

            if (_ruleset == null)
            {
                parameterIdRuleset.Value = DBNull.Value;
            }
            else
            {
                parameterIdRuleset.Value = _ruleset.Id;
            }

            cmd.ExecuteNonQuery();
        }
    }

    public IWorld? World
    {
        get
        {
            return _world;
        }
        set
        {
            _world = value;

            SqliteCommand cmd = new();
            cmd.Connection = MyMeta.Conn;
            cmd.CommandText =
                @"
                UPDATE `selected`
                SET `id_world` = @IdRuleset
                WHERE `id` = 1
                ";

            var parameterIdWorld = new SqliteParameter("@IdWorld", SqliteType.Integer);
            parameterIdWorld.IsNullable = true;

            if (_world == null)
            {
                parameterIdWorld.Value = DBNull.Value;
            }
            else
            {
                parameterIdWorld.Value = _world.Id;
            }

            cmd.ExecuteNonQuery();
        }
    }
}
