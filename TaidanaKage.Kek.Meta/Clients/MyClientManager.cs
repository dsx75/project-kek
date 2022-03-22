namespace TaidanaKage.Kek.Meta.Clients;

internal class MyClientManager : IClientManager
{
    private IClient? _current;

    internal MyClientManager()
    {
    }

    public IClient AddClient(string folder)
    {
        // TODO implement
        return null;
    }

    public IClient? Current
    {
        get
        {
            // TODO hardcoded value
            _current = new MyClient(@"F:\WoW\Clients\W3");
            return _current;
        }
    }
}