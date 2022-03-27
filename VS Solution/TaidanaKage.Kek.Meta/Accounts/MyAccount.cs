using NLog;

namespace TaidanaKage.Kek.Meta.Accounts;

internal class MyAccount : IAccount
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private readonly int _id;
    private readonly string _name;
    private readonly string _password;
    private readonly bool _isDeveloper;

    internal MyAccount(int id, string name, string password, bool isDeveloper)
    {
        // Are these checks here necessary? Eh, whatever. Better be safe than sorry.
        if (id < 1)
        {
            ArgumentOutOfRangeException ex = new(nameof(id), id, "Invalid Account ID.");
            logger.Error(ex);
            throw (ex);
        }
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

        _id = id;
        _name = name;
        _password = password;
        _isDeveloper = isDeveloper;
    }

    public int Id => _id;

    public string Name => _name;

    public string Password => _password;

    public bool IsDeveloper => _isDeveloper;
}
