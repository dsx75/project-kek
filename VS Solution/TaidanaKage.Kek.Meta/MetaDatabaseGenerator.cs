using Microsoft.Data.Sqlite;

namespace TaidanaKage.Kek.Meta;

/// <summary>
/// Meta Database generator.
/// <br/>
/// <br/>
/// 1. Creates a new file for the database.
/// <br/>
/// 2. Creates complete database structure (tables, indexes)
/// <br/>
/// 3. Inserts default data.
/// </summary>
internal class MetaDatabaseGenerator
{
    private readonly string _file;
    private readonly SqliteConnection _conn;

    internal MetaDatabaseGenerator(string file)
    {
        _file = file;
        _conn = new SqliteConnection("Data Source=" + _file);
    }

    internal void Run()
    {
        _conn.Open();

        // World versions
        CreateTableWorldVersions();
        InsertWorldVersions();

        // Worlds
        CreateTableWorlds();

        // Accounts
        CreateTableAccounts();
        InsertDefaultAdminAccount();
        InsertDefaultPlayerAccount();

        // Clients
        CreateTableClients();

        // Rulesets
        CreateTableRulesets();
        InsertDefaultRuleset();

        // Selected
        CreateTableSelected();
        InsertDefaultSelected();

        _conn.Close();
        _conn.Dispose();
    }

    private void Execute(string sql)
    {
        var command = _conn.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }

    private void CreateTableWorldVersions()
    {
        string sql = @"CREATE TABLE `world_versions`(
            `id` INTEGER PRIMARY KEY, 
            `name` TEXT NOT NULL,
            UNIQUE(`name`)
            );";
        Execute(sql);
    }

    private void InsertWorldVersions()
    {
        // TODO read these values from the enumeration
        InsertWorldVersion(1, "W1");
        InsertWorldVersion(2, "W2");
        InsertWorldVersion(3, "W3");
        InsertWorldVersion(4, "W4");
        InsertWorldVersion(5, "W5");
    }

    private void InsertWorldVersion(int id, string name)
    {
        var command = _conn.CreateCommand();
        command.CommandText = @"INSERT INTO `world_versions`(`id`, `name`) VALUES ($id, $name)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$name", name);
        command.ExecuteNonQuery();
    }

    private void CreateTableWorlds()
    {
        string sql = @"CREATE TABLE `worlds`(
            `id` INTEGER PRIMARY KEY, 
            `name` TEXT NOT NULL,
            `id_world_version` INTEGER NOT NULL,
            UNIQUE(`name`),
            FOREIGN KEY(`id_world_version`) REFERENCES `world_versions`(`id`)
            );";
        Execute(sql);
    }

    private void CreateTableAccounts()
    {
        string sql = @"CREATE TABLE `accounts`(
            `id` INTEGER PRIMARY KEY, 
            `name` TEXT NOT NULL,
            `password` TEXT NOT NULL,
            `id_last_world` INTEGER,
            UNIQUE(`name`)
            FOREIGN KEY(`id_last_world`) REFERENCES `worlds`(`id`)
            );";
        Execute(sql);
    }

    private void InsertDefaultAdminAccount()
    {
        // TODO hardcode values
        InsertAccount(1, "admin", "admin");
    }

    private void InsertDefaultPlayerAccount()
    {
        // TODO hardcode values
        InsertAccount(2, "player", "player");
    }

    private void InsertAccount(int id, string name, string password)
    {
        var command = _conn.CreateCommand();
        command.CommandText = @"INSERT INTO `accounts`(`id`, `name`, `password`) VALUES ($id, $name, $password)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$password", password);
        command.ExecuteNonQuery();
    }

    private void CreateTableClients()
    {
        string sql = @"CREATE TABLE `clients`(
            `id` INTEGER PRIMARY KEY, 
            `folder` TEXT NOT NULL,
            `exe_file_name` TEXT NOT NULL,
            `version_major` INTEGER NOT NULL,
            `version_minor` INTEGER NOT NULL,
            `version_build` INTEGER NOT NULL,
            `version_private` INTEGER NOT NULL,
            `id_world_version` INTEGER NOT NULL,
            `is_64_bit` INTEGER NOT NULL,
            UNIQUE(`folder`, `exe_file_name`),
            FOREIGN KEY(`id_world_version`) REFERENCES `world_versions`(`id`)
            );";
        Execute(sql);
    }

    private void CreateTableRulesets()
    {
        // TODO add world version
        string sql = @"CREATE TABLE `rulesets`(
            `id` INTEGER PRIMARY KEY, 
            `name` TEXT NOT NULL,
            UNIQUE(`name`)
            );";
        Execute(sql);
    }

    private void InsertDefaultRuleset()
    {
        var command = _conn.CreateCommand();
        command.CommandText = @"INSERT INTO `rulesets`(`id`, `name`) VALUES ($id, $name)";
        // TODO hardcoded values
        command.Parameters.AddWithValue("$id", 1);
        command.Parameters.AddWithValue("$name", "Default");
        command.ExecuteNonQuery();
    }

    private void CreateTableSelected()
    {
        string sql = @"CREATE TABLE `selected`(
            `id` INTEGER PRIMARY KEY, 
            `id_client` INTEGER, 
            `id_world_version` INTEGER, 
            `id_ruleset` INTEGER, 
            `id_world` INTEGER, 
            FOREIGN KEY(`id_client`) REFERENCES `clients`(`id`),
            FOREIGN KEY(`id_world_version`) REFERENCES `world_versions`(`id`),
            FOREIGN KEY(`id_ruleset`) REFERENCES `rulesets`(`id`),
            FOREIGN KEY(`id_world`) REFERENCES `worlds`(`id`)
            );";
        Execute(sql);
    }
    private void InsertDefaultSelected()
    {
        var command = _conn.CreateCommand();
        command.CommandText = @"INSERT INTO `selected`(`id`) VALUES ($id)";
        command.Parameters.AddWithValue("$id", 1);
        command.ExecuteNonQuery();
    }
}