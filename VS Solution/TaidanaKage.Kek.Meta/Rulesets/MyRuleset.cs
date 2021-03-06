using NLog;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta.Rulesets;

internal class MyRuleset : IRuleset
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private readonly int _id;
    private readonly WorldVersion _worldVersion;
    private readonly string _name;
    private readonly string _folder;

    internal MyRuleset(int id, WorldVersion worldVersion, string name, string folder)
    {
        // Are these checks here necessary? Eh, whatever. Better be safe than sorry.
        if (id < 1)
        {
            ArgumentOutOfRangeException ex = new(nameof(id), id, "Invalid Ruleset ID.");
            logger.Error(ex);
            throw (ex);
        }
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

        _id = id;
        _worldVersion = worldVersion;
        _name = name;
        _folder = folder;
    }

    public int Id => _id;

    public WorldVersion WorldVersion => _worldVersion;

    public string Name => _name;

    public string Folder => _folder;
}
