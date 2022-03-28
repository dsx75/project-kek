using NLog;

namespace TaidanaKage.Kek.Meta.Worlds;

internal class MyWorld : IWorld
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private readonly int _id;
    private readonly int _idRuleset;
    private readonly string _name;
    private readonly string _file;

    internal MyWorld(int id, int idRuleset, string name, string file)
    {
        // Are these checks here necessary? Eh, whatever. Better be safe than sorry.
        if (id < 1)
        {
            ArgumentOutOfRangeException ex = new(nameof(id), id, "Invalid World ID.");
            logger.Error(ex);
            throw (ex);
        }
        if (idRuleset < 1)
        {
            ArgumentOutOfRangeException ex = new(nameof(id), id, "Invalid Ruleset ID.");
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            ArgumentException ex = new("World's name cannot be empty.", nameof(name));
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(file))
        {
            ArgumentException ex = new("World's file cannot be empty.", nameof(file));
            logger.Error(ex);
            throw (ex);
        }

        _id = id;
        _idRuleset = idRuleset;
        _name = name;
        _file = file;
    }

    public int Id => _id;

    public int RulesetId => _idRuleset;

    public string Name => _name;

    public string File => _file;
}
