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
            if (_client == null)
            {
                _worldVersion = WorldVersion.Unknown;
            }
            else
            {
                _worldVersion = _client.WorldVersion;
            }
            // TODO update database
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
            // TODO update database
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
            // TODO update database
        }
    }
}