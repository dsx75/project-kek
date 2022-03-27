using NLog;

namespace TaidanaKage.Kek.Meta.Accounts;

internal class MyAcountManager : IAccountManager
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    internal MyAcountManager()
    {

    }

    public IAccount AddAccount(string name, string password, bool isDeveloper)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            ArgumentException ex = new("Account name cannot be empty.", nameof(name));
            logger.Error(ex);
            throw (ex);
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            ArgumentException ex = new("Password cannot be empty.", nameof(password));
            logger.Error(ex);
            throw (ex);
        }
        // TODO add checks for minimal length of name and password (clients require at least 2 characters?)

        var cmd = MyMeta.Conn.CreateCommand();
        cmd.CommandText =
            @"
            INSERT INTO `accounts` (`name`, `password`, `is_developer`)
            VALUES ($Id, $Name, $Password, $IsDeveloper)
            ";

        cmd.Parameters.AddWithValue("$Name", name);
        cmd.Parameters.AddWithValue("$Password", password);
        cmd.Parameters.AddWithValue("$IsDeveloper", isDeveloper);

        cmd.ExecuteNonQuery();

        // Let's find the ID of newly added Account
        int id = MyMeta.GetLastInsertRowId();

        return new MyAccount(id, name, password, isDeveloper);
    }

    public IAccount? GetAccount(int id)
    {
        var command = MyMeta.Conn.CreateCommand();
        command.CommandText =
            @"
            SELECT `name`, `password`, `is_developer`
            FROM `accounts`
            WHERE `id` = $Id
            ";
        command.Parameters.AddWithValue("$Id", id);

        IAccount? account = null;
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string name = reader.GetString(reader.GetOrdinal("name"));
                string password = reader.GetString(reader.GetOrdinal("password"));

                int iDev = reader.GetInt32(reader.GetOrdinal("is_developer"));
                bool isDeveloper = (iDev == 1);

                account = new MyAccount(id, name, password, isDeveloper);
            }
        }
        return account;
    }

    public List<int> Accounts()
    {
        var command = MyMeta.Conn.CreateCommand();
        command.CommandText =
            @"
            SELECT `id`
            FROM `accounts`
            ORDER BY `id`
            ";

        List<int> accounts = new();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("id"));
                accounts.Add(id);
            }
        }
        return accounts;
    }
}
