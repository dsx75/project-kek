using TaidanaKage.Kek.Common;
using TaidanaKage.Kek.Meta.Accounts;
using TaidanaKage.Kek.Meta.Clients;
using TaidanaKage.Kek.Meta.Rulesets;
using TaidanaKage.Kek.Meta.Worlds;

namespace TaidanaKage.Kek.Meta;

internal class MyMeta : IMeta
{
    private readonly string _folder;
    private readonly string _databaseFile;
    private readonly IAccountManager _accountManager;
    private readonly IClientManager _clientManager;
    private readonly IRulesetManager _rulesetManager;
    private readonly IWorldManager _worldManager;

    internal MyMeta()
    {
        _folder = Utils.MetaFolder;

        if (!Directory.Exists(_folder))
        {
            // TODO create the directory
        }

        _databaseFile = Path.Combine(_folder, Constants.MetaDatabaseFileName);

        if (!File.Exists(_databaseFile))
        {

        }

        _accountManager = new MyAcountManager();
        _clientManager = new MyClientManager();
        _rulesetManager = new MyRulesetManager();
        _worldManager = new MyWorldManager();
    }

    public string Folder => _folder;

    public string DatabaseFile => _databaseFile;

    public IAccountManager AccountManager => _accountManager;

    public IClientManager ClientManager => _clientManager;

    public IRulesetManager RulesetManager => _rulesetManager;

    public IWorldManager WorldManager => _worldManager;

    public void LoadToMemory()
    {
        throw new NotImplementedException();
    }

    public void SaveToDisk()
    {
        throw new NotImplementedException();
    }
}