using TaidanaKage.Kek.Meta.Rulesets;

namespace TaidanaKage.Kek.Meta.Worlds;

internal class MyWorldManager : IWorldManager
{
    internal MyWorldManager()
    {
    }

    public IWorld AddWorld(IRuleset ruleset, string name, string file)
    {
        throw new NotImplementedException();
    }

    public IWorld? GetWorld(int id)
    {
        throw new NotImplementedException();
    }

    public List<int> Worlds(IRuleset ruleset)
    {
        throw new NotImplementedException();
    }
}
