using NLog;
using SuperSimpleTcp;
using System.Text;
using TaidanaKage.WoW.Packets.W1.Login;

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

    // Loose coupling. We can call this library from a console application, Windows Forms application, etc.
    public delegate void DisplayInfo(string message);

    public static void Start(DisplayInfo displayInfo)
    {
        // Listening IP and Port
        _server = new SimpleTcpServer("127.0.0.1", 3724);

        // Server configuration
        _server.Events.ClientConnected += (sender, e) => ClientConnected(sender, e, displayInfo);
        _server.Events.ClientDisconnected += (sender, e) => ClientDisconnected(sender, e, displayInfo);
        _server.Events.DataReceived += (sender, e) => DataReceived(sender, e, displayInfo);

        _server.StartAsync();

        PacketManager.Start();

        string message = "WoW Meta Server started.";
        logger.Info(message);
        displayInfo(message);
    }

    public static void Stop(DisplayInfo displayInfo)
    {
        if (_server != null)
        {
            _server.Stop();
            _server.Dispose();
            string message = "WoW Meta Server stopped.";
            logger.Info(message);
            displayInfo(message);
        }
    }

    static void ClientConnected(object sender, ConnectionEventArgs e, DisplayInfo displayInfo)
    {
        string message = "[" + e.IpPort + "] client connected";
        logger.Info(message);
        displayInfo(message);
    }

    static void ClientDisconnected(object sender, ConnectionEventArgs e, DisplayInfo displayInfo)
    {
        string message = "[" + e.IpPort + "] client disconnected: " + e.Reason.ToString();
        logger.Info(message);
        displayInfo(message);
    }

    static void DataReceived(object sender, DataReceivedEventArgs e, DisplayInfo displayInfo)
    {
        IIncomingPacket packet = PacketManager.PacketReader.Parse(e.Data);

        string message = "[" + e.IpPort + "]: Data received, length " + packet.Length;
        displayInfo(message);
        logger.Info(message);
        logger.Debug(Encoding.UTF8.GetString(e.Data));
    }
}
