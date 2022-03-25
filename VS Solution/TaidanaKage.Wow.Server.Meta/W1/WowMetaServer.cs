using NLog;
using SuperSimpleTcp;
using System.Text;

namespace TaidanaKage.Wow.Server.Meta.W1;

/// <summary>
/// Wow Meta Server - version W1.
/// <br/>
/// This server is listening on: 127.0.0.1:3724
/// <br/>
/// This server is responsible for:
/// <br/>
/// - checking the client's version
/// <br/>
/// - authenticating player's Account (name, password)
/// <br/>
/// - sending list of available Worlds back to the client
/// <br/>
/// - retrieving selected/created Character from the client
/// </summary>
public static class WowMetaServer
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    private static SimpleTcpServer? _server;

    public static void Start()
    {
        // Listening IP and Port
        _server = new SimpleTcpServer("127.0.0.1", 3724);

        // Server configuration
        _server.Events.ClientConnected += ClientConnected;
        _server.Events.ClientDisconnected += ClientDisconnected;
        _server.Events.DataReceived += DataReceived;

        _server.StartAsync();
    }

    public static void Stop()
    {
        if (_server != null)
        {
            _server.Stop();
            _server.Dispose();
        }
    }

    static void ClientConnected(object sender, ConnectionEventArgs e)
    {
        logger.Info("[" + e.IpPort + "] client connected");
    }

    static void ClientDisconnected(object sender, ConnectionEventArgs e)
    {
        logger.Info("[" + e.IpPort + "] client disconnected: " + e.Reason.ToString());
    }

    static void DataReceived(object sender, DataReceivedEventArgs e)
    {
        logger.Info("[" + e.IpPort + "]: " + Encoding.UTF8.GetString(e.Data));
    }
}
