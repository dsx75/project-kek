using Microsoft.Data.Sqlite;
using NLog;
using TaidanaKage.Kek.Common;
using TaidanaKage.Kek.Meta.Accounts;
using TaidanaKage.Kek.Meta.Clients;
using TaidanaKage.Kek.Meta.Rulesets;
using TaidanaKage.Kek.Meta.Worlds;

namespace TaidanaKage.Kek.Meta;

internal class MyMeta : IMeta
{
    private readonly static Logger logger = LogManager.GetCurrentClassLogger();

    private readonly string _folder;
    private readonly string _databaseFile;
    private readonly IAccountManager _accountManager;
    private readonly IClientManager _clientManager;
    private readonly IRulesetManager _rulesetManager;
    private readonly IWorldManager _worldManager;

    /// <summary>
    /// This is private, because it may be <c>null</c>.
    /// Use <c>Conn</c> property instead. 
    /// </summary>
    private static SqliteConnection? _conn;

    internal MyMeta()
    {
        _folder = Utils.MetaFolder;

        if (!Directory.Exists(_folder))
        {
            Directory.CreateDirectory(_folder);
        }

        _databaseFile = Path.Combine(_folder, Constants.MetaDatabaseFileName);

        if (!File.Exists(_databaseFile))
        {
            new MetaDatabaseGenerator(_databaseFile).Run();
        }

        _conn = new SqliteConnection("Data Source=" + _databaseFile);

        // TODO Implement proper closing of this connection.
        _conn.Open();

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

    /// <summary>
    /// Central connection to the Meta Database, used (internally) by the whole Meta library.
    /// </summary>
    internal static SqliteConnection Conn
    {
        get
        {
            if (_conn == null)
            {
                Exception ex = new("Meta Database connection hasn't been established yet. Improper API usage. Come on, man.");
                logger.Error(ex);
                throw ex;
            }
            return _conn;
        }
    }
}