using NLog;

namespace TaidanaKage.Kek.Meta.Clients;

internal class MyClientManager : IClientManager
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    private int _selectedClientId;
    private IClient? _selectedClient;

    internal MyClientManager()
    {
        _selectedClientId = 0;
        _selectedClient = null;
    }

    public IClient AddClient(string exeFile)
    {
        // Since there's a lot of code involved, a separate class was created.
        return new ClientGenerator(exeFile).Run();
    }

    public IClient GetClient(int id)
    {
        return null;
    }

    public int SelectedClientId
    {
        get
        {
            return _selectedClientId;
        }
        set
        {
            _selectedClientId = value;
            _selectedClient = null;
        }
    }

    public IClient? SelectedClient
    {
        get
        {
            return _selectedClient;
        }
    }
}