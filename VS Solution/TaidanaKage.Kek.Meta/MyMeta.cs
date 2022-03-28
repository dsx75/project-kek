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

        bool isThisTheFirstRun = !File.Exists(_databaseFile);
        if (isThisTheFirstRun)
        {
            // Let's create a brand new Meta Database, including the complete structure (tables, keys).
            // Plus some harcoded data:
            // - list of World Versions
            // - an empty row for Selected
            new MetaDatabaseGenerator(_databaseFile).Run();
        }

        _conn = new SqliteConnection("Data Source=" + _databaseFile);

        // TODO Implement proper closing of this connection.
        _conn.Open();

        _accountManager = new MyAcountManager();
        _clientManager = new MyClientManager();
        _rulesetManager = new MyRulesetManager();
        _worldManager = new MyWorldManager();

        if (isThisTheFirstRun)
        {
            // Let's insert some default data into the new empty Meta Database

            // Default accounts
            _accountManager.AddAccount("admin", "admin", true);
            _accountManager.AddAccount("player", "player", false);

            // Default Rulesets
            _rulesetManager.AddRuleset(WorldVersion.W1, "Default W1", @"F:\WoW\KeK\Rulesets\W1");
            _rulesetManager.AddRuleset(WorldVersion.W2, "Default W2", @"F:\WoW\KeK\Rulesets\W2");
            _rulesetManager.AddRuleset(WorldVersion.W3, "Default W3", @"F:\WoW\KeK\Rulesets\W3");
            _rulesetManager.AddRuleset(WorldVersion.W4, "Default W4", @"F:\WoW\KeK\Rulesets\W4");
            _rulesetManager.AddRuleset(WorldVersion.W5, "Default W5", @"F:\WoW\KeK\Rulesets\W5");

            // TODO temporary hack
            _clientManager.AddClient(@"F:\WoW\Clients\W1\WoW.exe");
            _clientManager.AddClient(@"F:\WoW\Clients\W2\WoW.exe");
            _clientManager.AddClient(@"F:\WoW\Clients\W3\WoW.exe");
            _clientManager.AddClient(@"F:\WoW\Clients\W4\WoW.exe");
            _clientManager.AddClient(@"F:\WoW\Clients\W5\Wow64.exe");

            IRuleset? ruleset = _rulesetManager.GetRuleset(1);
            if (ruleset != null)
            {
                _worldManager.AddWorld(ruleset, "Test world", @"D:\test_world.db");
            }
        }
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

    /// <summary>
    /// Gets the ID of the record created by the last INSERT command.
    /// </summary>
    /// <returns>ID</returns>
    internal static int GetLastInsertRowId()
    {
        SqliteCommand cmd = new();
        cmd.Connection = Conn;
        cmd.CommandText = @"SELECT last_insert_rowid()";
        var result = cmd.ExecuteScalar();
        if (result == null)
        {
            // Something went wrong
            Exception ex = new("Unable to determine ID of the newly added record.");
            logger.Error(ex);
            throw ex;
        }
        Int64 id64 = (Int64)result;
        int id = Convert.ToInt32(id64);
        return id;
    }
}